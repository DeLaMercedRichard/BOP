using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 10;
    [SerializeField] float Sight = 1;
    
    private Transform player;

    [SerializeField] bool RotateAfterPlayer = false;  // By Blawnode
    [SerializeField] bool Jitter = false;  // By Blawnode
    public GameObject sprite;  // By Blawnode

    Animator animator;  // By Blawnode

    public enum ChaserType  // By Blawnode
    {
        DaughterBeetle,
        SpotGerm,
    }
    [SerializeField] ChaserType type = ChaserType.SpotGerm;  // By Blawnode

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();  // By Blawnode
    }

    // Update is called once per frame
    void Update()
    {
        Chaseplayer();
    }

    private void Chaseplayer()
    {
        float PlayerDistance = Vector2.Distance(player.position, transform.position);
        if (PlayerDistance < Sight)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, MovementSpeed * Time.deltaTime);

            if (type == ChaserType.DaughterBeetle)  // By Blawnode
            {
                Vector2 Direction = (player.transform.position - transform.position).normalized;  // By Blawnode
                animator.SetFloat("Horizontal", Direction.x);  // By Blawnode
                animator.SetFloat("Vertical", Direction.y);  // By Blawnode
            }
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
            sprite.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle + Random.Range(-5, 5f)));  // By Blawnode
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Sight);
    }
    
}

