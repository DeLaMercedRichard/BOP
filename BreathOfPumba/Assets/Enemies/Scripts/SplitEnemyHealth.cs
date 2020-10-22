using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitEnemyHealth : MonoBehaviour
{
    [SerializeField] int CurrentHealth = 100;
    [SerializeField] int MaxHealth = 100;
    [SerializeField] GameObject SummonParent;
    [SerializeField] GameObject Summon1;
    public GameObject HealthPickUp;
    public GameObject AmmoPickUp;
    public GameObject SpeedPickUp;
    int HealthSpawnRate = 5;
    int AmmoSpawnRate = 5;
    int SpeedSpawnRate = 5;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            SpawnPickUps();
            SummonMany(2);
            Destroy(gameObject);
        }
    }
    void SummonMany(int SummonAmount)
    {
        for (int i = 0; i < SummonAmount; i++)
        {
            GameObject Summon = Instantiate(Summon1, new Vector3(i * 1f, SummonParent.transform.position.y, i * 0.75f), SummonParent.transform.rotation);
        }
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
