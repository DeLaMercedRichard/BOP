using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{

    [SerializeField] int Damage = 10;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            other.gameObject.GetComponent<EnemyHealth>().DamageEnemy(Damage);
            
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "SplitEnemy")
        {
            other.gameObject.GetComponent<SplitEnemyHealth>().DamageEnemy(Damage);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "PlantEnemy")

        {
            other.gameObject.GetComponent<PlantEnemyHealth>().DamageEnemy(Damage);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "EnemySurvival")
        {
            other.gameObject.GetComponent<EnemyHealthSurvival>().DamageEnemy(Damage);
            Destroy(gameObject);
        }
    }
    
}
