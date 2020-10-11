using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float ProjectileSpeed = 1f;
    private Vector3 where;
    void Start()
    {
        where = transform.position;
        where = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        where.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, where, ProjectileSpeed * Time.deltaTime);
    }
}
