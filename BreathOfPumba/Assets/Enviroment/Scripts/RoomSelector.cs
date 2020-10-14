using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomSelector  : MonoBehaviour
{
    public Room room;
    public MapGeneration mapGenerator;
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
        if(!mapGenerator)
        mapGenerator = GetComponent<MapGeneration>();

        if (!room)
            room = GetComponent<Room>();
        room.SetSize(sizeX, sizeY);
        
        SetUpAssets();
       
        
    }

    private void SetUpAssets()
    {
        
    }

    public void DrawRoom(Vector3Int atPosition, int scaleX_, int scaleY_, string type_)
    {
        type = type_;
        scaleX = scaleX_;
        scaleY = scaleY_;
        room.SetScale(scaleX, scaleY);
        room.SetPosition(atPosition);
        room.DrawRoom();
    }

    private void DefineTypeOfRoom()
    {
        switch (type)
        {
            case "Start":
                room = new RectangleRoom();
                room.scaleX = 1;
                room.scaleY = 1;
                break;

            case "Basic":
                room = new RectangleRoom();
                room.scaleX = 1;
                room.scaleY = 1;
                break;
            case "MediumRoom":
                room = new RectangleRoom();
                room.scaleX = Mathf.RoundToInt(UnityEngine.Random.Range(1, 3));
                room.scaleY = Mathf.RoundToInt(UnityEngine.Random.Range(1, 3));
                break;

            case "LargeRoom":
                room = new RectangleRoom();
                room.scaleX = Mathf.RoundToInt(UnityEngine.Random.Range(2,4));
                room.scaleY = Mathf.RoundToInt(UnityEngine.Random.Range(2,4));
                break;

            case "Boss":
                room = new RectangleRoom();
                room.scaleX = 2;
                room.scaleY = 2;
                break;
            case "Treasure":
                room = new RectangleRoom();
                room.scaleX = 1;
                room.scaleY = 1;
                break;

            case "TrapTreasure":
                room = new RectangleRoom();
                room.scaleX = 1;
                room.scaleY = 1;
                break;

            //To Be Implemented in Future
            case "SpecialRoom":

            default:
                room = new RectangleRoom();
                break;
        }
    }

    
    //Define Rooms
    //Spawn
    
    //Enemy Room

    //Treasure Room

    //Boss

}
