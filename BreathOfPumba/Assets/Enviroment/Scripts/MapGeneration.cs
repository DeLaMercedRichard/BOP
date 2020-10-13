using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    [SerializeField]
    private Vector2Int worldSize = new Vector2Int(10, 10);
    [SerializeField]
    private RoomDetails[,] roomLayout;
    [SerializeField]
    private List<Vector2Int> takenPositions = new List<Vector2Int>();
    private int gridSizeX, gridSizeY;
    private int numberOfRooms = 20;

    public Room rooms;
    // Start is called before the first frame update
    void Start()
    {
        if (numberOfRooms >= (worldSize.x*2) * (worldSize.y*2))
        {
            numberOfRooms = (worldSize.x * 2) * (worldSize.y * 2);
        }
        gridSizeX = worldSize.x;
        gridSizeY = worldSize.y;

        PlanRooms();
        //SetRoomDoors
        //DrawMap
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlanRooms()
    {
        //Adding Starting Point 
        roomLayout = new RoomDetails[gridSizeX *2, gridSizeY *2];
        roomLayout[gridSizeX, gridSizeY] = new RoomDetails(Vector2Int.zero, "StartingRoom");
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
            roomLayout[(int)checkPosition.x + gridSizeX, (int)checkPosition.y + gridSizeY] = new RoomDetails(checkPosition, "RectangleRoom");
            takenPositions.Insert(0, checkPosition);
        }

    }
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
        foreach (RoomDetails room in roomLayout)
        {
            if (room == null)
            {
                continue; //skip where there is no room
            }
            //Add Room to Spot
           
        }
    }
    void SetRoomDoors()
    {
        for (int x = 0; x < ((gridSizeX * 2)); x++)
        {
            for (int y = 0; y < ((gridSizeY * 2)); y++)
            {
                if (roomLayout[x, y] == null)
                {
                    continue;
                }
                Vector2 gridPosition = new Vector2(x, y);
                if (y - 1 < 0)
                { //check below
                    roomLayout[x, y].entranceBot = false;
                }
                else
                {
                    roomLayout[x, y].entranceBot = (roomLayout[x, y - 1] != null);
                }
                if (y + 1 >= gridSizeY * 2)
                { //check top
                    roomLayout[x, y].entranceTop = false;
                }
                else
                {
                    roomLayout[x, y].entranceTop = (roomLayout[x, y + 1] != null);
                }
                if (x - 1 < 0)
                { //check left
                    roomLayout[x, y].entranceLeft = false;
                }
                else
                {
                    roomLayout[x, y].entranceLeft = (roomLayout[x - 1, y] != null);
                }
                if (x + 1 >= gridSizeX * 2)
                { //check right
                    roomLayout[x, y].entranceRight = false;
                }
                else
                {
                    roomLayout[x, y].entranceRight = (roomLayout[x + 1, y] != null);
                }
            }
        }
    }
}
