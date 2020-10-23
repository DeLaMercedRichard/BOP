﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimitGermPlanet : MonoBehaviour
{
    public float TimeLimit = 300;
    void Start()
    {
        StartCoroutine(TimeLimitCo());
    }

    IEnumerator TimeLimitCo()
    {
        yield return new WaitForSeconds(TimeLimit);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(TimeLimit);
    }
}
