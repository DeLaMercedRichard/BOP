using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
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
    public void DamagePlayer(int AmountOfDamage)
    {
        CurrentHealth -= AmountOfDamage;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HealthPickUp")
        {
            Heal();

        }

    }

    private void Heal()
    {
        if(CurrentHealth == MaxHealth)
        {
            Debug.Log("FullHealth");
        }
        else
        {
            CurrentHealth = MaxHealth;
        }
    }
}
