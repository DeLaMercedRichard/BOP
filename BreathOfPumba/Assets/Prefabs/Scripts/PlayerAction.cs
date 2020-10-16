﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject weaponswing;
    [SerializeField] float FireRate = 0.5f;
    [SerializeField] float ProjectileSpeed = 1f;
    [SerializeField] Camera MyCamera;
    public Transform weapon;
    //[SerializeField] Transform weapon;

    public Vector2 MousePosition;
    public Rigidbody2D Rigidb;
    
    Coroutine FireingCorutine;
    [SerializeField] bool Gun = true;
    
   

    // Update is called once per frame
    void Update()
    {
        WeaponRotation();
        if(Gun==true)
        {
            Fire();
        }
        else 
        {
            Swing();
            
        }
        
    }

    private void DetermindWeapon()
    {
        if (Gun == true)
        {
            Fire();
        }
        else
        {
            Swing();

        }
    }
    private void WeaponRotation()
    {
        // Vector2 WeaponPosition = Camera.main.WorldToViewportPoint(transform.position);
        //Vector2 MousePosition = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //float angle = Weaponangle(WeaponPosition, MousePosition);
        //transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        MousePosition = MyCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 LookDirection = MousePosition - Rigidb.position;
        float angle = Mathf.Atan2(LookDirection.y, LookDirection.x) * Mathf.Rad2Deg - 90f;
    } 

    float Weaponangle(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void Swing()
    { 
    
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject swordhit = Instantiate(weaponswing,weapon.position,weapon.rotation);
        }
    }
    private void Fire()
    {
    
        if (Input.GetButtonDown("Fire1"))
        {
            FireingCorutine = StartCoroutine(Fireing());

        }
        if (Input.GetButtonUp("Fire1"))
        {

            StopCoroutine(FireingCorutine);
        }

        IEnumerator Fireing()
        {
            while (true)
            {
                GameObject bullet = Instantiate(projectile, weapon.position, weapon.rotation);
                //Rigidbody2D Rigidb =
                //yield return new WaitForSeconds(FireRate);
            }
        }

     
    }
}
