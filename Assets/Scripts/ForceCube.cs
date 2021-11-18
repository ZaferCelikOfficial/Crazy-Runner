using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCube : MonoBehaviour
{
    Rigidbody rb;
    float xForce, yForce, zForce;
    float RandomxForce = 600f;
    float RandomyForce = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        yForce = Random.Range(0, RandomyForce);
        xForce = Random.Range(-RandomxForce, RandomxForce);
        zForce = Random.Range(-RandomxForce, RandomxForce);

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TouchForce();
        }
           
    }

    public void TouchForce()
    {
        rb.AddTorque(new Vector3(xForce,yForce));
    }
}
