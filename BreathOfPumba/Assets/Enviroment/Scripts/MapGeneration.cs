﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
/*
 Responsible for Placing the Rooms on the Grid and Seting up Grid and Rendering Rooms
     */
public class MapGeneration : MonoBehaviour
{

    [SerializeField]
    private Vector2Int worldSize;
    [SerializeField]
    private List<Vector2Int> takenPositions;
    [SerializeField]
    private RoomSelector roomSelected;
    private int gridSizeX, gridSizeY;
    [SerializeField]
    private int numberOfRooms;

    public RoomDetails[,] roomLayout;

    [Header("Prefabs")]
    [SerializeField]
    public Tilemap floor;
    [SerializeField]
    public Tilemap walls;
    [SerializeField]
    public Tilemap hazards;
    [SerializeField]
    public Tilemap obstacles;
    [SerializeField]
    public TileBase[] floorTileAsset;
    [SerializeField]
    public TileBase[] wallTileAsset;
    [SerializeField]
    public TileBase[] hazardTileAsset;
    [SerializeField]
    public TileBase[] objectTileAsset;

    [Header("Room Properties")]
    [SerializeField]
    public int defaultSizeX;
    [SerializeField]
    public int defaultSizeY;
    public string roomType;

    private void Awake()
    {
        SetAssets();
        //Layout where the rooms will take place by using a list of coordinates rather than actual objects
        PlanRooms();
        //Save Entrance Data for the Room's DrawRoom Function
        SetRoomDoors();
        //Initializing
        DrawMap();
    }
    // Start is called before the first frame update
    void Start()
    {

        //Setup
      
    }

    // Update is called once per frame
    void Update()
    {

    }

  
    void PlanRooms()
    {
        //Adding Starting Point  *assumes all rooms basic 1 x 1 scale
        takenPositions.Insert(0, Vector2Int.zero);
        Vector2Int checkPosition = Vector2Int.zero;
        //magic Numbers
        float randomCompare = 0.2f, randomCompareStart = 0.2f, randomCompareEnd = 0.01f;
        //Room Generation
        for (int it = 0; it < numberOfRooms - 1; it++)
        {
            float randomPerctange = ((float)it / ((float)(numberOfRooms - 1)));
            randomCompare = Mathf.Lerp(randomCompareStart, randomCompareEnd, randomPerctange);
            //grab new Position
            checkPosition = NewPosition();

            //test new Position
            if (NumberOfNeighbors(checkPosition, takenPositions) > 1 && Random.value > randomCompare)
            {
                int iterations = 0;
                do
                {
                    checkPosition = SelectiveNewPosition();
                    iterations++;
                } while (NumberOfNeighbors(checkPosition, takenPositions) > 1 && iterations < 100);
                if (iterations >= 50)
                    print("error: could not create with fewer neighbors than : " + NumberOfNeighbors(checkPosition, takenPositions));
            }
            //finalize position
            takenPositions.Insert(0, checkPosition);
        }

    }
    //Grabs a new random position from a point in position
    Vector2Int NewPosition()
    {
        int x = 0, y = 0;
        Vector2Int checkingPos = Vector2Int.zero;
        do
        {
            int index = Mathf.RoundToInt(Random.value * (takenPositions.Count - 1)); // pick a random room
            x = (int)takenPositions[index].x;//capture its x, y position
            y = (int)takenPositions[index].y;
            bool UpDown = (Random.value < 0.5f);//randomly pick wether to look on hor or vert axis
            bool positive = (Random.value < 0.5f);//pick whether to be positive or negative on that axis
            if (UpDown)
            { //find the position bnased on the above bools
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector2Int(x, y);
        } while (takenPositions.Contains(checkingPos) || x >= gridSizeX || x < -gridSizeX || y >= gridSizeY || y < -gridSizeY); //make sure the position is valid
        return checkingPos;
    }
    //(To Be implemented to make it fancy if we got time)
    Vector2Int SelectiveNewPosition()
    { // method differs from the above in the two commented ways
        int index = 0, inc = 0;
        int x = 0, y = 0;
        Vector2Int checkingPos = Vector2Int.zero;
        do
        {
            inc = 0;
            do
            {
                //instead of getting a room to find an adject empty space, we start with one that only 
                //as one neighbor. This will make it more likely that it returns a room that branches out
                index = Mathf.RoundToInt(Random.value * (takenPositions.Count - 1));
                inc++;
            } while (NumberOfNeighbors(takenPositions[index], takenPositions) > 1 && inc < 100);
            x = (int)takenPositions[index].x;
            y = (int)takenPositions[index].y;
            bool UpDown = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);
            if (UpDown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector2Int(x, y);
        } while (takenPositions.Contains(checkingPos) || x >= gridSizeX || x < -gridSizeX || y >= gridSizeY || y < -gridSizeY);
        if (inc >= 100)
        { // break loop if it takes too long: this loop isnt garuanteed to find solution, which is fine for this
            print("Error: could not find position with only one neighbor");
        }
        return checkingPos;
    }
    int NumberOfNeighbors(Vector2Int checkingPos, List<Vector2Int> usedPositions)
    {
        int ret = 0; // start at zero, add 1 for each side there is already a room
        if (usedPositions.Contains(checkingPos + Vector2Int.right))
        { //using Vector.[direction] as short hands, for simplicity
            ret++;
        }
        if (usedPositions.Contains(checkingPos + Vector2Int.left))
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPos + Vector2Int.up))
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPos + Vector2Int.down))
        {
            ret++;
        }
        return ret;
    }

    void DrawMap()
    {
        //Sets up Canvas Size
        roomSelected.SetUpBoundariesForTileMaps(gridSizeX * defaultSizeX +2, gridSizeY * defaultSizeY +2);
        roomType = "Start";
        //RoomType default set to Start

        for (int i = 0; i < takenPositions.Count; i++)
        {
           
            roomSelected.DrawRoom(
                new Vector3Int(
                    Mathf.RoundToInt(takenPositions[i].x * defaultSizeX * 1.05f),
                    Mathf.RoundToInt(takenPositions[i].y * defaultSizeY * 1.05f),
                    0),
                1,
                1,
                roomType);
           
            RoomDetails currentRoomDetails = roomLayout[takenPositions[i].x + worldSize.x, takenPositions[i].y + worldSize.y];
            roomSelected.AddEntrances(currentRoomDetails.entranceTop, currentRoomDetails.entranceBot, currentRoomDetails.entranceLeft, currentRoomDetails.entranceRight);
            //Debug.Log("Grid Position (" + (takenPositions[i].x) + " , " + (takenPositions[i].y) + ") entrances toggled: Top(" + roomLayout[takenPositions[i].x + worldSize.x, takenPositions[i].y + worldSize.y].entranceTop + "), Bottom(" + roomLayout[takenPositions[i].x + worldSize.x, takenPositions[i].y + worldSize.y].entranceBot + "), Left(" + roomLayout[takenPositions[i].x + worldSize.x, takenPositions[i].y + worldSize.y].entranceLeft + "), Right(" + roomLayout[takenPositions[i].x + worldSize.x, takenPositions[i].y + worldSize.y].entranceRight + ")");

            //After inital Room change Room Type
            //Make Last Room Boss
            if (i < takenPositions.Count - 2)
                roomType = "Basic";
            else
                roomType = "Boss";

        }//end for loop



    }
    void SetRoomDoors()
    {
        
        foreach (Vector2Int position in takenPositions)
        {
            //adding worldSize as an offset to ensure values remain positive
           roomLayout[(position.x + worldSize.x), (position.y + worldSize.y)] = new RoomDetails(position);
        } //end foreach

        //Debug.Log("Array Size: " + roomLayout.Length);

        for (int x = 0; x < ((gridSizeX * 2)); x++)
        {
            for (int y = 0; y < ((gridSizeY * 2)); y++)
            {
                if (roomLayout[x, y] == null)
                {
                    continue;
                }
                if ( y > 1 && roomLayout[x, y - 1] == null )
                { //check below
                    roomLayout[x, y].entranceBot = false;
                }
                else
                {
                    roomLayout[x, y].entranceBot = (roomLayout[x, y - 1] != null);
                }
                if (y < gridSizeY - 1 && roomLayout[x, y + 1] == null )
                { //check top
                    roomLayout[x, y].entranceTop = false;
                }
                else
                {
                    roomLayout[x, y].entranceTop = (roomLayout[x, y + 1] != null);
                }
                if (x > 1 && roomLayout[x - 1, y] == null )
                { //check left
                    roomLayout[x, y].entranceLeft = false;
                }
                else
                {
                    roomLayout[x, y].entranceLeft = (roomLayout[x - 1, y] != null);
                }
                if (x < gridSizeX - 1 && roomLayout[x + 1, y] == null )
                { //check right
                    roomLayout[x, y].entranceRight = false;
                }
                else
                {
                    roomLayout[x, y].entranceRight = (roomLayout[x + 1, y] != null);
                }

                //Debug.Log("Grid Position (" + (x) + " , " + (y) + ") entrances toggled: Top(" + roomLayout[x,y].entranceTop + "), Bottom(" + roomLayout[x, y].entranceBot + "), Left(" + roomLayout[x, y].entranceLeft + "), Right(" + roomLayout[x, y].entranceRight + ")");
            }//end nested for
        }//end for
    }
    void SetAssets()
    {
        if(worldSize == Vector2Int.zero)
        worldSize = new Vector2Int(5, 5);
        if(takenPositions == null)
        takenPositions = new List<Vector2Int>();
        if(numberOfRooms == 0)
        numberOfRooms = 10;

        roomType = "Start";

        //Setting World Settings
        if (numberOfRooms >= (worldSize.x * 2) * (worldSize.y * 2))
        {
            numberOfRooms = (worldSize.x * 2) * (worldSize.y * 2);
        }
        gridSizeX = worldSize.x;
        gridSizeY = worldSize.y;
        if (defaultSizeX == 0)
        {
            defaultSizeX = 20;
        }
        if (defaultSizeY == 0)
        {
            defaultSizeY = 20;
        }

        //Setting Assets
        roomLayout = new RoomDetails[worldSize.x *2 +2 , worldSize.y *2 +2];
        roomSelected.SetVariables(defaultSizeX, defaultSizeY);
        roomSelected.room.SetFloorTileAsset(floorTileAsset);
        roomSelected.room.SetFloorTileMap(floor);
        roomSelected.room.SetHazardTileAsset(hazardTileAsset);
        roomSelected.room.SetHazardTileMap(hazards);
        roomSelected.room.SetObjectTileAsset(objectTileAsset);
        roomSelected.room.SetObstaclesTileMap(obstacles);
        roomSelected.room.SetWallTileAsset(wallTileAsset);
        roomSelected.room.SetWallTileMap(walls);
    }
}
