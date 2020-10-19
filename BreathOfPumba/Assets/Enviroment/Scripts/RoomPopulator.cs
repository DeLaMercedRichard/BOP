using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
//Populates an area with prefabs given an area
public class RoomPopulator : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void PopulateRoom(Vector2Int position, GameObject gameObject, Vector2Int boundaries, int amount)
    {

        for (int i = 0; i < amount; i++)
        {

        }
        Instantiate(gameObject, new Vector3(position.x, position.y, 0), Quaternion.identity);
    }

    private bool CheckIfInBoundaries(Vector2Int position, Vector2Int boundaries)
    {
        return true;
    }

    private Vector2Int GetNewPosition(Vector2Int position, Vector2Int boundaries)
    {

        return Vector2Int.zero;
    }
}
