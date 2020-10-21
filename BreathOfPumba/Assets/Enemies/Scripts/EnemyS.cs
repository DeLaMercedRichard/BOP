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

    public enum ShooterType  // By Blawnode
    {
        Turret,
        SnakeGerm,
    }
    [SerializeField] ShooterType type = ShooterType.Turret;  // By Blawnode

    [SerializeField] bool RotateAfterPlayer = false;  // By Blawnode
    public GameObject sprite;  // By Blawnode

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

            if(type == ShooterType.Turret)  // By Blawnode
            {
                Vector2 Direction = (player.transform.position - transform.position).normalized;  // By Blawnode
                animator.SetFloat("Horizontal", Direction.x);  // By Blawnode
                animator.SetFloat("Vertical", Direction.y);  // By Blawnode
                animator.SetTrigger("Shoot");  // By Blawnode
            }

            FireTime = Time.time + FireRate;
        }


        if (RotateAfterPlayer)  // (This whole thing here) By Blawnode (https://answers.unity.com/questions/1350050/how-do-i-rotate-a-2d-object-to-face-another-object.html)
        {
            Vector3 target = player.transform.position;
            target.z = 0f;

            Vector3 enemyPos = transform.position;
            target.x = target.x - enemyPos.x;
            target.y = target.y - enemyPos.y;

            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

            //float angle = Vector2.SignedAngle(this.transform.position, player.position);  // By Blawnode
            sprite.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));  // By Blawnode
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Sight);
        Gizmos.DrawWireSphere(transform.position, FireingRange);
    }
}
