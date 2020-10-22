using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon3 : MonoBehaviour
{
    [SerializeField] float FireRate = 0.5f;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform weapon;
    [SerializeField] float ProjectileSpeed = 10f;
    public int MaxAmmoCapacity = 30;
    public int CurrentAmmoCapacity = 30;
    public int MaxAmmo = 2;
    public int CurrentAmmo;
    public float ReloadTime = 3f;
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
            if (CurrentAmmoCapacity > 0)
            {
                FireingCorutine = StartCoroutine(Fireing());
            }
            else
            {
                Debug.Log("OutOfAmmo");
            }


        }
        if (Input.GetButtonUp("Fire1"))
        {

            StopCoroutine(FireingCorutine);
        }

        IEnumerator Fireing()
        {
            GameObject bullet = Instantiate(projectile, weapon.position, weapon.rotation);
            CurrentAmmo--;
            CurrentAmmoCapacity--;
            bullet.GetComponent<Rigidbody2D>().velocity = weapon.right * ProjectileSpeed;
            yield return new WaitForSeconds(FireRate);
        }


    }
    private void AmmoLoad()
    {
        if (CurrentAmmoCapacity == MaxAmmoCapacity)
        {
            Debug.Log("FullAmmo");
        }
        else
        {
            CurrentAmmoCapacity = MaxAmmoCapacity;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AmmoPickUp")
        {
            AmmoLoad();

        }

    }
}
