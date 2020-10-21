using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Main;

    void Start()
    {
        Main = this;
    }

    public void SpawnBlood(Vector3 position, GameObject blood)
    {
        Instantiate(blood, position, blood.transform.rotation, null);
    }
}
