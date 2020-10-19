using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
/*Determines what kind of room will be placed into the MapGeneration class*/
public class RoomSelector  : MonoBehaviour
{
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
        DefineTypeOfRoom();
        
        room.SetScale(scaleX, scaleY);
        room.SetPosition(atPosition);

        room.DrawRoom();
    }

    //Creates entrances 
    public void AddEntrances(bool top, bool bot, bool left, bool right)
    {

        room.CreateEntrances(top, bot, left, right); 
    }

    private void DefineTypeOfRoom()
    {
        switch (type)
        {
            case "Start":
           
                room.scaleX = 1;
                room.scaleY = 1;

                //*SetUpBoundariesForTileMaps


                break;

            case "Basic":
                
                room.scaleX = 1;
                room.scaleY = 1;
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
                
                room.scaleX = 2;
                room.scaleY = 2;
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
    //Spawn
    
    //Enemy Room

    //Treasure Room

    //Boss

}
