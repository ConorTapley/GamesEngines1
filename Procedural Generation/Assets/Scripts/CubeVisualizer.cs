using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeVisualizer : MonoBehaviour
{
    
    public GameObject cubePrefab;
    GameObject[] cubes = new GameObject[512];
    public float maxScale = 30;
    public float radius = 50f;
    public float cubeSize = 4f;

    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject instanceCube = (GameObject)Instantiate(cubePrefab);
            instanceCube.transform.position = this.transform.position;
            instanceCube.transform.parent = this.transform;
            instanceCube.name = "Cube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            instanceCube.transform.position = Vector3.forward * radius;
            cubes[i] = instanceCube;
        }
    }
    

    void Update()
    {
        

        for (int i = 0; i < 512; i++)
        {
            if(cubes != null)
            {
                cubes[i].transform.localScale = new Vector3(cubeSize, AudioPeer.samples[i] * maxScale, cubeSize);
            }
        }
    }
}
