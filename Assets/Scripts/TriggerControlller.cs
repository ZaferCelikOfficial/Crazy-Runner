using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControlller : MonoBehaviour
{
    ForceCube PlayerForceCube;
    void Start()
    {
        PlayerForceCube = GetComponent<ForceCube>();
    }
    void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.tag=="Sphere")
        {
            PlayerForceCube.TouchForce();
        }
    }
}
