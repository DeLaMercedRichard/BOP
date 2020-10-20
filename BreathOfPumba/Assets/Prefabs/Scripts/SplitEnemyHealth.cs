using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitEnemyHealth : MonoBehaviour
{
    [SerializeField] int CurrentHealth = 100;
    [SerializeField] int MaxHealth = 100;
    [SerializeField] GameObject SummonParent;
    [SerializeField] GameObject Summon1;
    
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            SummonMany(2);
            Destroy(gameObject);
        }
    }
    void SummonMany(int SummonAmount)
    {
        for (int i = 0; i < SummonAmount; i++)
        {
            GameObject Summon = Instantiate(Summon1, new Vector3(i * .6f, SummonParent.transform.position.y, i * 0.75f), SummonParent.transform.rotation);
            Summon.transform.parent = SummonParent.transform;
        }
    }
    public void DamageEnemy(int AmountOfDamage)
    {
        CurrentHealth -= AmountOfDamage;
    }
}
