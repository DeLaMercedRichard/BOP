using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int CurrentHealth = 100;
    [SerializeField] int MaxHealth = 100;
    [SerializeField] GameObject bloodType;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }
    
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            ParticleManager.Main.SpawnBlood(transform.position, bloodType);  // By Blawnode
            Destroy(gameObject);
        }
    }
    public void DamageEnemy(int AmountOfDamage)
    {
        CurrentHealth -= AmountOfDamage;
    }
}
