using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentFollow : MonoBehaviour
{
    NavMeshAgent EnemyAgent;
    Movement playerMovement;

    void Start()
    {
        EnemyAgent = GetComponent<NavMeshAgent>();
        playerMovement = FindObjectOfType<Movement>();
    }

    void Update()
    {
        EnemyAgent.SetDestination(playerMovement.transform.position);
        
        if (EnemyAgent.remainingDistance <3.5f&&EnemyAgent.remainingDistance>0)
        {
            
            switch (this.gameObject.tag)
            {
                case "Mickey":
                    this.GetComponent<Animator>().SetBool("isCatching", true);
                    Invoke("EnemyTriggered", 0.8f);
                    break;
                case "Zombie":
                    this.GetComponent<Animator>().SetBool("isCatching", true);
                    Invoke("EnemyTriggered", 0.8f);
                    break;
                case "Drake":
                    this.GetComponent<Animator>().SetBool("isCatching", true);
                    Invoke("EnemyTriggered", 0.8f);
                    break;
            }
        }
        
    }
    public void EnemyTriggered()
    {
        GameManager.instance.EndGame();
        GameManager.instance.OnLevelFailed();
    }
}
