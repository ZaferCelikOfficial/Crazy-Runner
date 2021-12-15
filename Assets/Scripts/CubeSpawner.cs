using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] GameObject MickeyPrefab;
    [SerializeField] GameObject DrakePrefab;
    [SerializeField] GameObject ZombiePrefab;
    [SerializeField] GameObject ShootingBoardPrefab;
    [SerializeField] GameObject SpawnArea1;
    [SerializeField] GameObject SpawnArea2;
    [SerializeField] GameObject SpawnArea3;

    Animator MickeyAnimator, ZombieAnimator, DrakeAnimator;

    ObjectPooler objectPooler;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(GameManager.LevelNumber==1)
            {
                switch (this.gameObject.tag)
                {
                    case "FirstWave":
                        for (int i = 0; i < 3; i++)
                        {
                            
                            SpawnArea1.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), SpawnArea1.transform.position.y, SpawnArea1.transform.position.z+Random.Range(-10f,10f));
                            GameObject instantiatedMickey = ObjectPooler.Instance.SpawnForGameObject("Mickey", SpawnArea1.transform.position, Quaternion.identity);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            int factor = -i;
                            Vector3 BoardSpawnArea = Vector3.up * 2.5f + Vector3.right * 3.5f * factor + SpawnArea1.transform.position;
                            GameObject instantiatedBoard = ObjectPooler.Instance.SpawnForGameObject("ShootingBoard", BoardSpawnArea, Quaternion.identity);
                        }

                        break;
                    case "SecondWave":
                        
                        for (int i = 0; i < 2; i++)
                        {
                            GameObject instantiatedZombie = ObjectPooler.Instance.SpawnForGameObject("Zombie", SpawnArea2.transform.position, Quaternion.identity);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            int factor = i * -1;
                            Vector3 BoardSpawnArea = Vector3.up * 2 * i + Vector3.right * 3 * factor + SpawnArea2.transform.position;
                            GameObject instantiatedBoard = ObjectPooler.Instance.SpawnForGameObject("ShootingBoard", BoardSpawnArea, Quaternion.identity);
                        }
                        break;
                    case "ThirdWave":
                        for (int i = 0; i < 1; i++)
                        {
                            GameObject instantiatedDrake = ObjectPooler.Instance.SpawnForGameObject("Drake", SpawnArea3.transform.position, Quaternion.identity);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            GameObject instantiatedZombie = ObjectPooler.Instance.SpawnForGameObject("Zombie", SpawnArea3.transform.position, Quaternion.identity);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            int factor = i * -1;
                            Vector3 BoardSpawnArea = Vector3.up * 2.5f * i + Vector3.right * 4 * factor + SpawnArea3.transform.position;
                            GameObject instantiatedBoard = ObjectPooler.Instance.SpawnForGameObject("ShootingBoard", BoardSpawnArea, Quaternion.identity);
                        }
                        break;
                }
            }
            if (GameManager.LevelNumber == 2)
            {
                switch (this.gameObject.tag)
                {

                    case "FirstWave":
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject instantiatedMickey = ObjectPooler.Instance.SpawnForGameObject("Mickey", SpawnArea1.transform.position, Quaternion.identity);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            int factor = -i;
                            Vector3 BoardSpawnArea = Vector3.up * 2.5f + Vector3.right * 3.5f * factor + SpawnArea1.transform.position;
                            GameObject instantiatedBoard = ObjectPooler.Instance.SpawnForGameObject("ShootingBoard", BoardSpawnArea, Quaternion.identity);
                        }

                        break;
                    case "SecondWave":
                        for (int i = 0; i < 1; i++)
                        {
                            GameObject instantiatedMickey = ObjectPooler.Instance.SpawnForGameObject("Mickey", SpawnArea2.transform.position, Quaternion.identity);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            GameObject instantiatedZombie = ObjectPooler.Instance.SpawnForGameObject("Zombie", SpawnArea2.transform.position, Quaternion.identity);
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            int factor = i * -1;
                            Vector3 BoardSpawnArea = Vector3.up * 2 * i + Vector3.right * 3 * factor + SpawnArea2.transform.position;
                            GameObject instantiatedBoard = ObjectPooler.Instance.SpawnForGameObject("ShootingBoard", BoardSpawnArea, Quaternion.identity);
                        }
                        break;
                    case "ThirdWave":
                        for (int i = 0; i < 1; i++)
                        {
                            GameObject instantiatedDrake = ObjectPooler.Instance.SpawnForGameObject("Drake", SpawnArea3.transform.position, Quaternion.identity);
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject instantiatedMickey = ObjectPooler.Instance.SpawnForGameObject("Mickey", SpawnArea3.transform.position, Quaternion.identity);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            int factor = i * -1;
                            Vector3 BoardSpawnArea = Vector3.up * 2.5f * i + Vector3.right * 4 * factor + SpawnArea3.transform.position;
                            GameObject instantiatedBoard = ObjectPooler.Instance.SpawnForGameObject("ShootingBoard", BoardSpawnArea, Quaternion.identity);
                        }
                        break;

                }
            }
            
        }        
    }
}
