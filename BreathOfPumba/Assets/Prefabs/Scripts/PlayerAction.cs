﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
   
    
    
    
   

    Animator animator;  // By Blawnode

    private void Start()
    {
        animator = transform.parent.GetComponent<Animator>();  // By Blawnode
    }

    // Update is called once per frame
    void Update()
    {
        WeaponRotation();
       
    }

  
    private void WeaponRotation()
    {
         Vector2 WeaponPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 MousePosition = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = Weaponangle(WeaponPosition, MousePosition);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));




        Vector2 angleVector = (Vector2)(Quaternion.Euler(0, 0, angle) * Vector2.right);  // By Blawnode, https://answers.unity.com/questions/823090/equivalent-of-degree-to-vector2-in-unity.html
        if (System.Math.Abs(-angleVector.x) > 0.01) animator.SetFloat("Horizontal", -angleVector.x);  // By Blawnode
        if (System.Math.Abs(-angleVector.y) > 0.01) animator.SetFloat("Vertical", -angleVector.y);  // By Blawnode
    }

    float Weaponangle(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    
    
}
