using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 10;
    [SerializeField] float Sight = 1;
    
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Sight);
    }
    
}

