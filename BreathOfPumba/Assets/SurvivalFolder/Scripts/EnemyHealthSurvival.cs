using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSurvival : MonoBehaviour
{
    [SerializeField] int CurrentHealth = 100;
    [SerializeField] int MaxHealth = 100;
    public GameObject HealthPickUp;
    public GameObject AmmoPickUp;
    public GameObject SpeedPickUp;
    public GameObject Weapon2PickUp;
    public GameObject Weapon3PickUp;
    public GameObject Weapon4PickUp;
    int Weapon2PickUpRate = 5;
    int Weapon3PickUpRate = 5;
    int Weapon4PickUpRate = 5;
    int HealthSpawnRate = 5;
    int AmmoSpawnRate = 5;
    int SpeedSpawnRate = 5;
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
    }
    public void DamageEnemy(int AmountOfDamage)
    {
        CurrentHealth -= AmountOfDamage;
    }
    
    private void SpawnPickUps()
    {
        SpawnWeapon2();
        SpawnWeapon3();
        SpawnWeapon4();
        SpawnSpeed();
        SpawnHealth();
    }
    private void SpawnHealth()
    {
        int randomdrop = Random.Range(1, 101);
        if (randomdrop <= HealthSpawnRate)
        {
            Instantiate(HealthPickUp, transform.position, transform.rotation);
        }

    }
    private void SpawnWeapon2()
    {
        int randomdrop = Random.Range(1, 101);
        if (randomdrop <= Weapon2PickUpRate)
        {
            Instantiate(Weapon2PickUp, transform.position, transform.rotation);
        }

    }
    private void SpawnWeapon3()
    {
        int randomdrop = Random.Range(1, 101);
        if (randomdrop <= Weapon3PickUpRate)
        {
            Instantiate(Weapon3PickUp, transform.position, transform.rotation);
        }

    }
    private void SpawnWeapon4()
    {
        int randomdrop = Random.Range(1, 101);
        if (randomdrop <= Weapon4PickUpRate)
        {
            Instantiate(Weapon4PickUp, transform.position, transform.rotation);
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
}
