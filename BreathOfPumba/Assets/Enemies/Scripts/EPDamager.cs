using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPDamager : MonoBehaviour
{
    [SerializeField] int Damage = 10;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().DamagePlayer(Damage);
            Destroy(gameObject);
        }
    }
}
