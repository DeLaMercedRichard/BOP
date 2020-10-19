using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    [SerializeField] float FireRate = 0.5f;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform weapon;
    [SerializeField] float ProjectileSpeed = 1f;
    public int MaxAmmo = 7;
    public int CurrentAmmo;
    public float ReloadTime = 2f;
    private bool reloadingNow = false;
    Coroutine FireingCorutine;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Reloading");
        CurrentAmmo = MaxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        if(reloadingNow)
        {
            return;
        }

        if(CurrentAmmo <= 0)
        {
            StartCoroutine(reloading());
            return;
        }
    }
    IEnumerator reloading()
    {
        reloadingNow = true;
        yield return new WaitForSeconds(ReloadTime);
        CurrentAmmo = MaxAmmo;
        reloadingNow = false;
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
                    CurrentAmmo--;
                    bullet.GetComponent<Rigidbody2D>().velocity = weapon.right * ProjectileSpeed;
                    yield return new WaitForSeconds(FireRate);
                
            }
        }


    }
}
