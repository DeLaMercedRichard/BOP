using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;
/*Determines what kind of room will be placed into the MapGeneration class and populates Rooms based on Type*/
public class RoomSelector : MonoBehaviour
{
    [Header("General Fields")]
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject bigEnemy;
    [SerializeField]
    GameObject chaseEnemy;
    [SerializeField]
    GameObject shootingEnemy;
    [SerializeField]
    GameObject summonerEnemy;
    [SerializeField]
    GameObject turretEnemy;
    [SerializeField]
    GameObject weakEnemy;
    [SerializeField]
    GameObject endGoal;
    [Space(10)]
    [Header("Survival Mode")]
    [SerializeField]
    bool survivalModeToggled = false;
    private bool spawnBool = false;

    [SerializeField]
    int waveDuration = 10;
    [Space(10)]
    [Header("Room Fields")]
    public Room room;
    public RoomDetails details;
    public string level;
    public int scaleX, scaleY;
    private string type;
    [SerializeField]
    private Dictionary<string, List<Vector2Int>> Map = new Dictionary<string, List<Vector2Int>>();
    public List<Vector2Int> visitedPlaces , nonVisited;

    [Space(10)]
    [Header("Spawn Details")]
    int spawnDistance;

    enum Dificulty
    {
        Easy, Medium, Hard
    }

    private void Awake()
    {
        if (visitedPlaces == null)
            visitedPlaces = new List<Vector2Int>();
        player = FindObjectOfType<Player>().gameObject;
    }
    //Responsible for returning a Room back 
    // Start is called before the first frame update
    private void Start()
    {
       
        if (survivalModeToggled) 
        InvokeRepeating("PopulateRooms", 1.0f, 30.0f);
      
    }
    private void Update()
    {
        //Spawn Monsters When Entering New Room
        if (!survivalModeToggled)
        {
            //check areas on map that not visited

           
           //Issue (not being updated?)
            Vector2Int playerposition = new Vector2Int(Mathf.RoundToInt(player.transform.position.x), Mathf.RoundToInt(player.transform.position.y));
            Debug.Log("Player Position: " + playerposition);
            foreach (KeyValuePair<string, List<Vector2Int>> rooms in Map)
            {
                //Now you can access the key and value both separately from this attachStat as:
               // Debug.Log(rooms.Key);
               // Debug.Log(rooms.Value);
                //Gets all the positions added
                foreach (Vector2Int room_ in rooms.Value)
                {
                    
                    if (!visitedPlaces.Contains(room_))
                    {
                        //Check if player is near room entrance 
                        Vector2Int vector = playerposition - room_;
                        int magnitude = (int)Math.Sqrt((double)(vector.x * vector.x + vector.y * vector.y));
                        if (Math.Abs(magnitude) < 40)
                        {

                            //Spawn based on type
                            if (chaseEnemy != null)
                                room.PopulateRoom(chaseEnemy, new Vector2Int(room_.x, room_.y), Mathf.RoundToInt(Random.Range(1, 4)));
                            if (weakEnemy != null)
                                room.PopulateRoom(weakEnemy, new Vector2Int(room_.x, room_.y), Mathf.RoundToInt(Random.Range(1, 4)));
                            if (shootingEnemy != null)
                                room.PopulateRoom(shootingEnemy, new Vector2Int(room_.x, room_.y), Mathf.RoundToInt(Random.Range(1, 4)));
                            if (summonerEnemy != null)
                                room.PopulateRoom(summonerEnemy, new Vector2Int(room_.x, room_.y), Mathf.RoundToInt(Random.Range(1, 4)));
                            if (turretEnemy != null)
                                room.PopulateRoom(turretEnemy, new Vector2Int(room_.x, room_.y), Mathf.RoundToInt(Random.Range(1, 4)));

                            visitedPlaces.Add(room_);
                        }
                    }
                }
                //Check if visited room (don't spawn stuff in room and ignore rooms)
               
              
            }
        }
    }
    public void SetVariables(int sizeX, int sizeY)
    {

        if (!room)
            room = GetComponent<Room>();
        room.SetSize(sizeX, sizeY);



    }

    public void DrawRoom(Vector3Int atPosition, int scaleX_, int scaleY_, string type_)
    {

        nonVisited.Add(new Vector2Int(atPosition.x, atPosition.y));
        //Add To Map 
        if (!Map.ContainsKey(type_))
            Map.Add(type_, nonVisited);
        else
        {
            //update List
            Map[type_] = nonVisited;
        }

        //Add Initial Places
        if (type_ == "Start")
        {
            visitedPlaces.Add(new Vector2Int(atPosition.x, atPosition.y));
        }
        type = type_;
        scaleX = scaleX_;
        scaleY = scaleY_;
        DefineTypeOfRoom(atPosition);
        //Replaces the scale settings in DefinteTypeOfRoom() later
        room.SetScale(scaleX, scaleY);
        room.SetPosition(atPosition);

        room.DrawRoom();
    }

    //Creates entrances 
    public void AddEntrances(bool top, bool bot, bool left, bool right)
    {

        room.CreateEntrances(top, bot, left, right);
    }


    private void DefineTypeOfRoom(Vector3Int position)
    {

        switch (type)
        {
            case "Start":

                room.scaleX = 1;
                room.scaleY = 1;
                //Spawn Stuff
                if (player != null)
                {
                    room.PopulateRoom(player, new Vector2Int(position.x, position.y), 1);
                }
                    
                //*SetUpBoundariesForTileMaps


                break;

            case "Basic":

                room.scaleX = 1;
                room.scaleY = 1;
                //Spawn 1-4 Enemies of each enemy except big enemy
                //if (chaseEnemy != null)
                //    room.PopulateRoom(chaseEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(1, 4)));
                //if (weakEnemy != null)
                //    room.PopulateRoom(weakEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(1, 4)));
                //if (shootingEnemy != null)
                //    room.PopulateRoom(shootingEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(1, 4)));
                //if (summonerEnemy != null)
                //    room.PopulateRoom(summonerEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(1, 4)));
                //if (turretEnemy != null)
                //    room.PopulateRoom(turretEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(1, 4)));

                break;
            case "MediumRoom":

                room.scaleX = Mathf.RoundToInt(UnityEngine.Random.Range(1, 3));
                room.scaleY = Mathf.RoundToInt(UnityEngine.Random.Range(1, 3));
                break;

            case "LargeRoom":

                room.scaleX = Mathf.RoundToInt(UnityEngine.Random.Range(2, 4));
                room.scaleY = Mathf.RoundToInt(UnityEngine.Random.Range(2, 4));
                break;

            case "Boss":

                room.scaleX = 1;
                room.scaleY = 1;
                //Summons Enemies
                if (endGoal != null)
                    room.PopulateRoom(endGoal, new Vector2Int(position.x, position.y), 1);
                if (bigEnemy != null)
                    room.PopulateRoom(bigEnemy, new Vector2Int(position.x, position.y), 1);
                if (chaseEnemy != null)
                    room.PopulateRoom(chaseEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(2, 6)));
                if (weakEnemy != null)
                    room.PopulateRoom(weakEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(2, 6)));
                if (shootingEnemy != null)
                    room.PopulateRoom(shootingEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(2, 6)));
                if (summonerEnemy != null)
                    room.PopulateRoom(summonerEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(2, 6)));
                if (turretEnemy != null)
                    room.PopulateRoom(turretEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(2, 6)));
                break;
            case "Treasure":

                room.scaleX = 1;
                room.scaleY = 1;
                break;

            case "TrapTreasure":

                room.scaleX = 1;
                room.scaleY = 1;
                break;

            //To Be Implemented in Future
            case "EndRoom":
                if (endGoal != null)
                    room.PopulateRoom(endGoal, new Vector2Int(position.x, position.y), 1);
                room.scaleX = 1;
                room.scaleY = 1;
                //Summons Enemies
                if (bigEnemy != null)
                    room.PopulateRoom(bigEnemy, new Vector2Int(position.x, position.y), 1);
                if (chaseEnemy != null)
                    room.PopulateRoom(chaseEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(2, 6)));
                if (weakEnemy != null)
                    room.PopulateRoom(weakEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(2, 6)));
                if (shootingEnemy != null)
                    room.PopulateRoom(shootingEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(2, 6)));
                if (summonerEnemy != null)
                    room.PopulateRoom(summonerEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(2, 6)));
                if (turretEnemy != null)
                    room.PopulateRoom(turretEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(2, 6)));
                break;

            default:

                break;
        }//end switch


    }


    //Sets canvas size for tiles to be drawn on the TIleMaps
    public void SetUpBoundariesForTileMaps(int worldSizeX, int worldSizeY)
    {
        room.floor.ClearAllTiles();
        room.floor.SetTile(new Vector3Int(-worldSizeX, worldSizeY, 0), room.floorTileAsset[0]);
        room.floor.SetTile(new Vector3Int(worldSizeX, -worldSizeY, 0), room.floorTileAsset[0]);

        room.walls.ClearAllTiles();
        room.walls.SetTile(new Vector3Int(-worldSizeX, worldSizeY, 0), room.wallTileAsset[0]);
        room.walls.SetTile(new Vector3Int(worldSizeX, -worldSizeY, 0), room.wallTileAsset[0]);

        room.hazards.ClearAllTiles();
        room.hazards.SetTile(new Vector3Int(-worldSizeX, worldSizeY, 0), room.wallTileAsset[0]);
        room.hazards.SetTile(new Vector3Int(worldSizeX, -worldSizeY, 0), room.wallTileAsset[0]);

        room.obstacles.ClearAllTiles();
        room.obstacles.SetTile(new Vector3Int(-worldSizeX, worldSizeY, 0), room.wallTileAsset[0]);
        room.obstacles.SetTile(new Vector3Int(worldSizeX, -worldSizeY, 0), room.wallTileAsset[0]);
    }


    //Populates All Visited Places
    public void PopulateRooms()
    {



        foreach (Vector2Int position in visitedPlaces)
        //Summons Enemies
        {
            //Summons Enemies
            if (bigEnemy != null)
                room.PopulateRoom(bigEnemy, new Vector2Int(position.x, position.y), 1);
            if (endGoal != null)
                room.PopulateRoom(endGoal, new Vector2Int(position.x, position.y), 1);
            if (chaseEnemy != null)
                room.PopulateRoom(chaseEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(2, 6)));
            if (weakEnemy != null)
                room.PopulateRoom(weakEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(2, 6)));
            if (shootingEnemy != null)
                room.PopulateRoom(shootingEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(2, 6)));
            if (summonerEnemy != null)
                room.PopulateRoom(summonerEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(2, 6)));
            if (turretEnemy != null)
                room.PopulateRoom(turretEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(2, 6)));
        }



    }
    //Define Rooms
    //Spawn Player


    //Enemy Room

    //Treasure Room

    //Boss

}
