using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentFollow : MonoBehaviour
{
    NavMeshAgent EnemyAgent;


    // Start is called before the first frame update
    void Start()
    {
        EnemyAgent = GetComponent<NavMeshAgent>();
    }
    

    // Update is called once per frame
    void Update()
    {
        EnemyAgent.SetDestination(PlayerPositionReader.PlayerPosition);
           
    }
}
