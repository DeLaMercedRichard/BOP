using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDetails
{
    [SerializeField]
    public Vector2Int gridPosition;
    [SerializeField]
    public string type;

    public bool entranceTop, entranceBot, entranceLeft, entranceRight;

    public RoomDetails(Vector2Int gridPosition_, string type_)
    {
        gridPosition = gridPosition_;
        type = type_;
    }
}
