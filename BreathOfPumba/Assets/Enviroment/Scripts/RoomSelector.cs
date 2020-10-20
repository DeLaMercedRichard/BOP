using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;
/*Determines what kind of room will be placed into the MapGeneration class and populates Rooms based on Type*/
public class RoomSelector  : MonoBehaviour
{
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

    public Room room;
    public RoomDetails details;
    public string level;
    public int scaleX, scaleY;
    private string type;

    //Responsible for returning a Room back 
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void SetVariables(int sizeX, int sizeY)
    {
 
        if (!room)
            room = GetComponent<Room>();
        room.SetSize(sizeX, sizeY);
        
       
        
    }
    
    public void DrawRoom(Vector3Int atPosition, int scaleX_, int scaleY_, string type_)
    {
       
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
                if(player != null)
                room.PopulateRoom(player,new Vector2Int(position.x, position.y), 1);
                //*SetUpBoundariesForTileMaps


                break;

            case "Basic":
                
                room.scaleX = 1;
                room.scaleY = 1;
                //Spawn 1-4 Enemies of each enemy except big enemy
                if (chaseEnemy != null)
                    room.PopulateRoom(chaseEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(1,4)));
                if (weakEnemy != null)
                    room.PopulateRoom(weakEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(1, 4)));
                if (shootingEnemy != null)
                    room.PopulateRoom(shootingEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(1, 4)));
                if (summonerEnemy != null)
                    room.PopulateRoom(summonerEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(1, 4)));
                if (turretEnemy != null)
                    room.PopulateRoom(turretEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(1, 4)));

                break;
            case "MediumRoom":
                
                room.scaleX = Mathf.RoundToInt(UnityEngine.Random.Range(1, 3));
                room.scaleY = Mathf.RoundToInt(UnityEngine.Random.Range(1, 3));
                break;

            case "LargeRoom":
                
                room.scaleX = Mathf.RoundToInt(UnityEngine.Random.Range(2,4));
                room.scaleY = Mathf.RoundToInt(UnityEngine.Random.Range(2,4));
                break;

            case "Boss":
                
                room.scaleX = 1;
                room.scaleY = 1;
                //Summons Enemies
                if (bigEnemy != null)
                    room.PopulateRoom(bigEnemy, new Vector2Int(position.x, position.y), 1);
                if (chaseEnemy != null)
                    room.PopulateRoom(chaseEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(1, 4)));
                if (weakEnemy != null)
                    room.PopulateRoom(weakEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(1, 4)));
                if (shootingEnemy != null)
                    room.PopulateRoom(shootingEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(1, 4)));
                if (summonerEnemy != null)
                    room.PopulateRoom(summonerEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(1, 4)));
                if (turretEnemy != null)
                    room.PopulateRoom(turretEnemy, new Vector2Int(position.x, position.y), Mathf.RoundToInt(Random.Range(1, 4)));
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
            case "SpecialRoom":

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


    //Define Rooms
    //Spawn Player

    
    //Enemy Room

    //Treasure Room

    //Boss

}
