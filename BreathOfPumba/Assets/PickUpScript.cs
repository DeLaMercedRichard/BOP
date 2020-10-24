using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(CollectPickUp(other.gameObject));
        }
    }

    public void GetPickedUp(GameObject other)  // By BN
    {
        //StartCoroutine(CollectPickUp(other));
        print("PICK");
        Destroy(gameObject);
    }

    IEnumerator CollectPickUp(GameObject other)
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}

