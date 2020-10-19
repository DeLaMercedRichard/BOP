using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //**Set Room Type Variables**//

    [SerializeField]
    int numberOfRooms;
    [SerializeField]
    int maxNumberOfRooms;
    //Location of Rooms based on index of array
    [SerializeField]
    List<Room> rooms;

    [SerializeField]
    List<Vector3Int> roomPlacementList;
    // Start is called before the first frame update
    void Start()
    {
        //AddRoom
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddRoom(Vector3Int position, int sizeX, int sizeY, int type)
    {
        //See if Room can be added to Position
        switch (type)
        {
            case 0:
                rooms.Add(new RectangleRoom());
                break;
            case 1:
            default:
                rooms.Add(new RectangleRoom());
                break;
        }


    }
}
