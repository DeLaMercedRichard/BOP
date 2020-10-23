using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponselectSurvival : MonoBehaviour
{
    public int selectedWeapon = 0;
    public float weapon2Time = 30;
    public float weapon3Time = 30;
    public float weapon4Time = 30;
    [SerializeField] GameObject ammoText = null;  // By Blawnode
    void Start()
    {
        SelectedWeapon();
    }

    private void SelectedWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    void Update()
    {
        int PreviousWeapon = selectedWeapon;
        
        

        if (PreviousWeapon != selectedWeapon)
        {
            SelectedWeapon();
        }
    }

    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon2PickUp")
        {
            Weapon2Load();

        }
        if (other.gameObject.tag == "Weapon3PickUp")
        {
            Weapon3Load();

        }
        if (other.gameObject.tag == "Weapon4PickUp")
        {
            Weapon4Load();

        }
    }
    private void Weapon2Load()
    {
        StartCoroutine(Weapon2Co());
    }

    IEnumerator Weapon2Co()
    {
        selectedWeapon = 1;
        yield return new WaitForSeconds(weapon2Time);
        selectedWeapon = 0;

    }
    private void Weapon3Load()
    {
        StartCoroutine(Weapon3Co());
    }

    IEnumerator Weapon3Co()
    {
        selectedWeapon = 2;
        yield return new WaitForSeconds(weapon3Time);
        selectedWeapon = 0;

    }
    private void Weapon4Load()
    {
        StartCoroutine(Weapon4Co());
    }

    IEnumerator Weapon4Co()
    {
        selectedWeapon = 3;
        yield return new WaitForSeconds(weapon3Time);
        selectedWeapon = 0;

    }
    
}
