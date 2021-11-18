using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionReader : MonoBehaviour
{
    public static Vector3 PlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition = this.transform.position;
    }
}
