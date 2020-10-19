using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
/*
 Used to pass information from and to Map Generation and SelectRoom so that MapGeneration doesn't have to include Rooms
     */
public class RoomDetails
{
    
    [SerializeField]
    public int scaleX;
    [SerializeField]
    public int scaleY;

    [SerializeField]
    public int numberOfEntrances;

    [SerializeField]
    public Vector2Int gridPosition;
    [SerializeField]
    public string type;

    public bool entranceTop = false, entranceBot = false, entranceLeft = false, entranceRight = false;

    public RoomDetails(Vector2Int gridPosition_)
    {
        
    }
    
}
