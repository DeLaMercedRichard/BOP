﻿using System;
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
        ammoText.GetComponent<TextMeshProUGUI>().enabled = (selectedWeapon == 0);  // By Blawnode
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
