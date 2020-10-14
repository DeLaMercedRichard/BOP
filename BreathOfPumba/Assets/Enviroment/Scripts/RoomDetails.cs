using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomDetails
{
    
    [SerializeField]
    public int scaleX;
    [SerializeField]
    public int scaleY;

    
    [SerializeField]
    public bool topConnected, bottomConnected, rightConnected, leftConnected;
    [SerializeField]
    public int numberOfEntrances;

    [SerializeField]
    public Vector2Int gridPosition;
    [SerializeField]
    public string type;

    public bool entranceTop, entranceBot, entranceLeft, entranceRight;

    public RoomDetails(Vector2Int gridPosition_, string type_)
    {
        gridPosition = gridPosition_;
        type = type_;
        UpdatePositionInRelationToOffset();
    }

    public void UpdatePositionInRelationToOffset()
    {
       
    }
}
