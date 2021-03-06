﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon1 : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float FireRate = 0.5f;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform weapon;
    [SerializeField] float ProjectileSpeed = 1f;
    [SerializeField] GameObject ammoText;  // By Blawnode
    public int MaxAmmo = 7;
    public int CurrentAmmo;
    public float ReloadTime = 2f;
    public bool reloadingNow = false;
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
        ammoText.GetComponent<TextMeshProUGUI>().text = string.Format("Ammo: {0}/{1}", CurrentAmmo, MaxAmmo);  // By Blawnode
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
            ammoText.GetComponent<TextMeshProUGUI>().text = string.Format("Ammo: {0}/{1}", CurrentAmmo, MaxAmmo);  // By Blawnode
            bullet.GetComponent<EnemyDamager>().ApplyDamageModifier(player.GetComponent<Player>().CurrentDamageModifier);
            yield return new WaitForSeconds(FireRate);
        }
    }

    public void AmmoBoost()
    {
        CurrentAmmo = MaxAmmo;
        ammoText.GetComponent<TextMeshProUGUI>().text = string.Format("Ammo: {0}/{1}", CurrentAmmo, MaxAmmo);  // By Blawnode
    }
}
    
