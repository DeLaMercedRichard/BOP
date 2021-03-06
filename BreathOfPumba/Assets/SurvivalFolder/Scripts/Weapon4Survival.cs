﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon4Survival : MonoBehaviour
{
    [SerializeField] float FireRate = 0.5f;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform weapon;
    [SerializeField] float ProjectileSpeed = 10f;
    public int MaxAmmo = 30;
    public int CurrentAmmo = 30;
    public float ReloadTime = 4f;
    private bool reloadingNow = false;
    Coroutine FireingCorutine;


    void Start()
    {
        CurrentAmmo = MaxAmmo;
    }

    void Update()
    {
        Fire();
        if (reloadingNow)
        {
            return;
        }

        if (CurrentAmmo <= 0)
        {


            StartCoroutine(reloading());
            return;

        }
    }

    IEnumerator reloading()
    {
        print("Reloading...");
        reloadingNow = true;
        yield return new WaitForSeconds(ReloadTime);
        print("Done!");
        CurrentAmmo = MaxAmmo;
        reloadingNow = false;
    }

    private void Fire()
    {

        if (Input.GetButtonDown("Fire1") && CurrentAmmo > 0)
        {


            FireingCorutine = StartCoroutine(Fireing());



        }
        if (Input.GetButtonUp("Fire1"))
        {

            StopCoroutine(FireingCorutine);
        }

        IEnumerator Fireing()
        {
            GameObject bullet = Instantiate(projectile, weapon.position, weapon.rotation);
            CurrentAmmo--;

            bullet.GetComponent<Rigidbody2D>().velocity = weapon.right * ProjectileSpeed;
            yield return new WaitForSeconds(FireRate);
        }


    }





}
