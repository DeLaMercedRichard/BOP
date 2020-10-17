using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EProjectile : MonoBehaviour
{
    GameObject target;
    Rigidbody2D ProjectileRB;
    public GameObject spriteObject;  // By Blawnode

    [SerializeField] float ProjectileSpeed = 5;
    void Start()
    {
        ProjectileRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 Direction = (target.transform.position - transform.position).normalized * ProjectileSpeed;
        ProjectileRB.velocity = new Vector2(Direction.x, Direction.y);
        var angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;  // By Blawnode, https://answers.unity.com/questions/654222/make-sprite-look-at-vector2-in-unity-2d-1.html
        spriteObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);  // By Blawnode, https://answers.unity.com/questions/654222/make-sprite-look-at-vector2-in-unity-2d-1.html
        Destroy(this.gameObject, 2);
    }
}
