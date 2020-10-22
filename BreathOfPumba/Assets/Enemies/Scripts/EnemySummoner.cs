using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummoner : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 10;
    [SerializeField] float Sight = 1;
    [SerializeField] float FireingRange = 1;
    [SerializeField] float FireRate = 1;
    private float FireTime;
    [SerializeField] GameObject Summon;
    [SerializeField] GameObject BulletParent;


    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        Chaseplayer();
    }

    private void Chaseplayer()
    {
        float PlayerDistance = Vector2.Distance(player.position, transform.position);
        if (PlayerDistance < Sight && PlayerDistance > FireingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, MovementSpeed * Time.deltaTime);
        }
        else if (PlayerDistance <= FireingRange && FireTime < Time.time)
        {
            Instantiate(Summon, BulletParent.transform.position, Quaternion.identity);
            FireTime = Time.time + FireRate;

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Sight);
        Gizmos.DrawWireSphere(transform.position, FireingRange);
    }
}
