using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] int Damage = 10;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerHurtBox")
        {

            other.gameObject.GetComponent<PlayerHealth>().DamagePlayer(Damage);
            
            other.GetComponentInParent<PlayerHealth>().DamagePlayer(Damage);
        }
    }
}
