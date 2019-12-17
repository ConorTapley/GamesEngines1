using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    private Color colour;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        colour = new Color(Random.Range(0F, 1F), Random.Range(0, 1F), Random.Range(0, 1F));
        GetComponent<Renderer>().material.color = colour;
    }
}
