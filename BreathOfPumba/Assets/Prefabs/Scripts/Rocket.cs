using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] ParticleSystem ps_takeoff;
    private Animator animator;
    [SerializeField] Player player;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeOff()
    {
        animator.Play("Take Off");
    }

    public void StartParticles()
    {
        ps_takeoff.Play();
    }

    // Level complete!!
    public void TookOff()
    {
        print("GG!");
        player.GetComponent<Player>().ReachedGoal();
    }
}
