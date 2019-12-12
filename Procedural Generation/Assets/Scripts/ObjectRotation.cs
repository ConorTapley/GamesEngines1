using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    private GameObject planet;
    [SerializeField] private float rotationSpeed = 2f;

    void Start()
    {
        planet = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //planet.transform.eulerAngles = new Vector3(planet.transform.eulerAngles.x, planet.transform.eulerAngles.y * rotationSpeed, planet.transform.eulerAngles.z);
        planet.transform.Rotate(0, rotationSpeed, 0);
    }
}
