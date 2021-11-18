using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] GameObject MickeyPrefab;
    [SerializeField] GameObject DrakePrefab;
    [SerializeField] GameObject ZombiePrefab;
    [SerializeField] GameObject SpawnArea;
    Animator MickeyAnimator, ZombieAnimator, DrakeAnimator;

    ObjectPooler objectPooler;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Instantiate(MickeyPrefab, SpawnArea.transform.position, Quaternion.identity);
        //AgentFollow.EnemyAgent.SetDestination(PlayerModel.transform.position);
        for (int i=0; i<10;i++)
        {
            ObjectPooler.Instance.SpawnForGameObject("Mickey", SpawnArea.transform.position, Quaternion.identity);
            MickeyAnimator = MickeyPrefab.GetComponent<Animator>();
            ZombieAnimator = ZombiePrefab.GetComponent<Animator>();
            DrakeAnimator = DrakePrefab.GetComponent<Animator>();
            MickeyAnimator.SetBool("isCatching", false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //ObjectPooler.Instance.SpawnForGameObject("Cube", transform.position, Quaternion.identity);
        //ObjectPooler.Instance.SpawnForGameObject("Sphere", transform.position, Quaternion.identity);
        //Instantiate(CubePrefab, this.transform.position, Quaternion.identity);
    }
}
