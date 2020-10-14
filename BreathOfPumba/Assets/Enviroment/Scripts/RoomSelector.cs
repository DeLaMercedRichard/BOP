using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelector   
{
    public Room room;
    public RoomDetails details;
    public string type;

    //Responsible for returning a Room back 
    // Start is called before the first frame update
    public RoomSelector(RoomDetails details_)
    {
        details = details_;
    }

    public void DrawRoom()
    {
        room.DrawRoom();
    }

    private void DefineTypeOfRoom()
    {
        switch (details.type)
        {
            case "Start":
                room = new RectangleRoom();
               
                break;

            case "Basic":
                break;

            case "LargeRoom":
                break;

            case "Boss":
                break;
            
            case "Treasure":
                break;

            case "TrapTreasure":
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
