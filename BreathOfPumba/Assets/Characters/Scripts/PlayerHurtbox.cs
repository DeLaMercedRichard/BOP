using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtbox : MonoBehaviour
{
    [SerializeField] Player player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SlowBullet")
        {
            player.Slow();
        }
        if (other.gameObject.tag == "RootBullet")
        {
            player.Root();
        }
        if (other.gameObject.tag == "SpeedPickUp")
        {
            player.SpeedUp(other.gameObject);
        }
        if (other.gameObject.tag == "HealthPickUp")
        {
            player.Heal(other.gameObject);
        }
        if (other.gameObject.tag == "DamagePickUp")
        {
            player.DamageUp(other.gameObject);
        }
        if (other.gameObject.tag == "AmmoPickUp")
        {
            player.AmmoUp(other.gameObject);
        }
    }
}
