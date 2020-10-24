using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float StartingTime = 0;
    public float CurrentTime = 0;
    public TextMeshPro TimeCount;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = StartingTime;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += 1 * Time.deltaTime;
        TimeCount.text = CurrentTime.ToString("0");
    }
}
