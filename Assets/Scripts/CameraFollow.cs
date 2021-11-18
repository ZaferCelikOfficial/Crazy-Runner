using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Player;
    float Distance;
    [SerializeField] float SmoothTime=0.3f;
    Vector3 Velocity=Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Distance = Player.position.z - transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x, transform.position.y, Player.position.z - Distance),ref Velocity,SmoothTime);
    }
}
