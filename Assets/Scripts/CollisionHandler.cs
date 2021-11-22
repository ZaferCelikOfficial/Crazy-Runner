using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    Animator PlayerAnimator;
    Animator MickeyAnimator,ZombieAnimator,DrakeAnimator;
    [SerializeField] GameObject PlayerModel;
    public GameObject Mickey, Zombie, Drake;
    
    void Start()
    {
        PlayerAnimator = PlayerModel.GetComponent<Animator>();
        MickeyAnimator = Mickey.GetComponent<Animator>();
        ZombieAnimator = Zombie.GetComponent<Animator>();
        DrakeAnimator = Drake.GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision some one");
    }


    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            
            case "Finish":
                OnFinish();
                break;
            /*case "Mickey":
                other.GetComponent<Animator>().SetBool("isCatching", true);
                Invoke("EnemyTriggered",0.8f);
                break;
            case "Zombie":
                other.GetComponent<Animator>().SetBool("isCatching", true);
                Invoke("EnemyTriggered", 0.8f);
                break;
            case "Drake":
                other.GetComponent<Animator>().SetBool("isCatching", true);
                Invoke("EnemyTriggered", 0.8f);
                break;*/
        }
    }
    public void OnFinish()
    {
        GameManager.instance.EndGame();
        GameManager.instance.OnLevelCompleted();
        
        PlayerAnimator.SetBool("isFinishing", true);
        Debug.Log("Time Passed:"+Time.time+" Seconds");
    }
    public void EnemyTriggered()
    {
        GameManager.instance.EndGame();
        GameManager.instance.OnLevelFailed();
    }
    
}
