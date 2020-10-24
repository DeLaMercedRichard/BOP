using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    public float AmountOfTime = 300f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeLimitCo());
    }

    IEnumerator TimeLimitCo()
    {
        yield return new WaitForSeconds(AmountOfTime);
        //what happens when you run out of time
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
