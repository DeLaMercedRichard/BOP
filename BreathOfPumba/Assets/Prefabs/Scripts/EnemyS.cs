using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 10;
    [SerializeField] float Sight = 1;
    [SerializeField] float FireingRange = 1;
    [SerializeField] float FireRate = 1;
    private float FireTime;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject BulletParent;

    Animator animator;  // By Blawnode

    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();  // By Blawnode
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
        else if(PlayerDistance <= FireingRange && FireTime <Time.time)
        {
            Instantiate(Bullet, BulletParent.transform.position, Quaternion.identity);

            Vector2 Direction = (player.transform.position - transform.position).normalized;  // By Blawnode
            animator.SetFloat("Horizontal", Direction.x);  // By Blawnode
            animator.SetFloat("Vertical", Direction.y);  // By Blawnode
            animator.SetTrigger("Shoot");  // By Blawnode

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
