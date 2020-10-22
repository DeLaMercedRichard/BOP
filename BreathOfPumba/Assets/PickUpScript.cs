using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(CollectPickUp());

        }
    }
    IEnumerator CollectPickUp()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}

