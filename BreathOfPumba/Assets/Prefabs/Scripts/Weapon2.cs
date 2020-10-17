using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{

    [SerializeField] float FireRate = 0.5f;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform weapon;
    [SerializeField] float ProjectileSpeed = 1f;
    Coroutine FireingCorutine;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Fire();
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
                bullet.GetComponent<Rigidbody2D>().velocity = weapon.right * -ProjectileSpeed;
                yield return new WaitForSeconds(FireRate);
            }
        }


    }

}
