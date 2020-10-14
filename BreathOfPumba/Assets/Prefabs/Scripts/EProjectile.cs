using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EProjectile : MonoBehaviour
{
    GameObject target;
    Rigidbody2D ProjectileRB;
    [SerializeField] float ProjectileSpeed = 5;
    void Start()
    {
        ProjectileRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 Direction = (target.transform.position - transform.position).normalized * ProjectileSpeed;
        ProjectileRB.velocity = new Vector2(Direction.x, Direction.y);
        Destroy(this.gameObject, 2);
    }
}
