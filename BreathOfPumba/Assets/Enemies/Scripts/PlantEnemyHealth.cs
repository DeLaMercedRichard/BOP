using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemyHealth : MonoBehaviour
{
    [SerializeField] int CurrentHealth = 100;
    [SerializeField] int MaxHealth = 100;
    public GameObject HealthPickUp;
    public GameObject AmmoPickUp;
    public GameObject SpeedPickUp;
    int HealthSpawnRate = 5;
    int AmmoSpawnRate = 5;
    int SpeedSpawnRate = 5;
    public float regenRate = 2f;
    public int RegenAmount = 10;
    [SerializeField] GameObject bloodType;
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        if (CurrentHealth <= 0)
        {
            SpawnPickUps();
            ParticleManager.Main.SpawnBlood(transform.position, bloodType);  // By Blawnode
            Destroy(gameObject);

        }
        if(CurrentHealth < MaxHealth)
        {
            StartCoroutine(Regen());
        }
    }
    IEnumerator Regen()
    {
        yield return new WaitForSeconds(regenRate);
        RegenAmount += CurrentHealth;
    }
    public void DamageEnemy(int AmountOfDamage)
    {
        CurrentHealth -= AmountOfDamage;
    }
    private void SpawnHealth()
    {
        int randomdrop = Random.Range(1, 101);
        if (randomdrop <= HealthSpawnRate)
        {
            Instantiate(HealthPickUp, transform.position, transform.rotation);
        }

    }
    private void SpawnAmmo()
    {
        int randomdrop = Random.Range(1, 101);
        if (randomdrop <= AmmoSpawnRate)
        {
            Instantiate(AmmoPickUp, transform.position, transform.rotation);
        }

    }
    private void SpawnSpeed()
    {
        int randomdrop = Random.Range(1, 101);
        if (randomdrop <= SpeedSpawnRate)
        {
            Instantiate(SpeedPickUp, transform.position, transform.rotation);
        }

    }
    private void SpawnPickUps()
    {
        SpawnSpeed();
        SpawnAmmo();
        SpawnHealth();
    }
}
