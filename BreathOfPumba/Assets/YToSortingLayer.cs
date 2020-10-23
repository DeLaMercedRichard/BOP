// By Blawnode

using System.Collections.Generic;
using UnityEngine;

public class YToSortingLayer : MonoBehaviour
{
    private List<SpriteRenderer> renderers = new List<SpriteRenderer>();

    void Start()
    {
        foreach (SpriteRenderer r in GetComponentsInChildren(typeof(SpriteRenderer), false))
        {
            renderers.Add(r);
        }
    }

    void Update()
    {
        foreach (SpriteRenderer r in renderers)
        {
            r.sortingOrder = (int)(transform.position.y * -100);
        }
    }
}
