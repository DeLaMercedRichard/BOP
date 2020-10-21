using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
//Populates an area with prefabs given an area
public class RoomPopulator : MonoBehaviour
{
    List<Vector2Int> objectPositions = new List<Vector2Int>();
  
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    //boundaries = radius, position indicatesroom origin
    public void PopulateRoom(Vector2Int position, GameObject gameObject, Vector2Int boundaries, int amount)
    {
        Vector2Int newPosition;
        newPosition = position;
        for (int i = 0; i < amount; i++)
        {
            //Check if position is already taken (skip the first placement)
            if(objectPositions.Count > 0)
            { 
                //if taken look for a new positon
                if (objectPositions.Contains(newPosition))
                {
                    newPosition = GetNewPosition(position, boundaries);
                }
            }
            //Track Object Positions to prevent overlapping
            objectPositions.Add(newPosition);

            //Instantiate Prefab
            Instantiate(gameObject, new Vector3(newPosition.x, newPosition.y, 0), Quaternion.identity);
        }
       
    }

    //Recursive Function -> Calls itself until a non-overlapping value is found
    Vector2Int GetNewPosition(Vector2Int position, Vector2Int boundaries)
    {
        Vector2Int updatedPosition; 
        //Takes Random value within the boundaries of the room
        int xValue = Mathf.RoundToInt(Random.Range(position.x - boundaries.x +2, position.x + boundaries.x -2));
        int yValue = Mathf.RoundToInt(Random.Range(position.y - boundaries.y +2, position.y + boundaries.y -2));
        updatedPosition = new Vector2Int(xValue, yValue);
        //if not found return Vector
        if (!objectPositions.Contains(updatedPosition))
        {
            return updatedPosition;
        }
        else
        {
            //else call function again
            return GetNewPosition(position, boundaries);
        }

        
    }
    
}
