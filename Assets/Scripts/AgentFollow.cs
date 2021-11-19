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
