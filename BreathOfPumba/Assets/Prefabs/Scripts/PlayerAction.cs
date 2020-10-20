using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    Animator animator;  // By Blawnode

    private void Start()
    {
        animator = transform.parent.GetComponent<Animator>();  // By Blawnode
    }
    
    void Update()
    {
        WeaponRotation();

    }

    private void WeaponRotation()
    {
        Vector2 WeaponPosition = transform.position;
        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Weaponangle(WeaponPosition, MousePosition) - 180f;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    float Weaponangle(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
