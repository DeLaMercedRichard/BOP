﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int CurrentHealth = 100;
    [SerializeField] int MaxHealth = 100;
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void DamageEnemy(int AmountOfDamage)
    {
        CurrentHealth -= AmountOfDamage;
    }
}