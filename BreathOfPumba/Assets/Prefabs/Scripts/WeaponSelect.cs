using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSelect : MonoBehaviour
{
    public int selectedWeapon = 0;
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
            /*if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }*/
            if (i == selectedWeapon)
            {
                if (weapon.TryGetComponent<Weapon1>(out Weapon1 script1))
                {
                    script1.enabled = true;
                    ammoText.GetComponent<TextMeshProUGUI>().text = string.Format("Ammo: {0}/{1}", script1.CurrentAmmo, script1.MaxAmmo);  // By Blawnode
                }
                else if (weapon.TryGetComponent<Weapon2>(out Weapon2 script2))
                {
                    script2.enabled = true;
                    ammoText.GetComponent<TextMeshProUGUI>().text = string.Format("Ammo: {0}/{1}", script2.CurrentAmmo, script2.MaxAmmo);  // By Blawnode
                }
                else if (weapon.TryGetComponent<Weapon3>(out Weapon3 script3))
                {
                    script3.enabled = true;
                    ammoText.GetComponent<TextMeshProUGUI>().text = string.Format("Ammo: {0}/{1}", script3.CurrentAmmo, script3.MaxAmmo);  // By Blawnode
                }
                else if (weapon.TryGetComponent<Weapon4>(out Weapon4 script4))
                {
                    script4.enabled = true;
                    ammoText.GetComponent<TextMeshProUGUI>().text = string.Format("Ammo: {0}/{1}", script4.CurrentAmmo, script4.MaxAmmo);  // By Blawnode
                }
            }
            else
            {
                if (weapon.TryGetComponent<Weapon1>(out Weapon1 script1))
                {
                    script1.enabled = false;
                }
                else if (weapon.TryGetComponent<Weapon2>(out Weapon2 script2))
                {
                    script2.enabled = false;
                }
                else if (weapon.TryGetComponent<Weapon3>(out Weapon3 script3))
                {
                    script3.enabled = false;
                }
                else if (weapon.TryGetComponent<Weapon4>(out Weapon4 script4))
                {
                    script4.enabled = false;
                }
            }
            i++;
        }
        //ammoText.GetComponent<TextMeshProUGUI>().enabled = (selectedWeapon != 1);  // By Blawnode
    }
    
    void Update()
    {
        int PreviousWeapon = selectedWeapon;
        ScrollWheelControl();
        NumberControls();

        if (PreviousWeapon != selectedWeapon)
        {
            SelectedWeapon();
        }
    }

    private void NumberControls()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }
        
    }
    
    private void ScrollWheelControl()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }
    }
}
