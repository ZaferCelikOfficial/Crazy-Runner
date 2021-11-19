using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killing : MonoBehaviour
{
    public int MickeyHealth=1, ZombieHealth=2, DrakeHealth=3, ShootingBoardHealth=1;
    public int PointsCollected=0;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Bullet")
            switch(this.gameObject.tag)
            {
                case "Mickey":
                    {
                        MickeyHealth--;
                        if (MickeyHealth <= 0)
                        {
                            this.gameObject.SetActive(false);
                            PointsCollected += 10;
                            Debug.Log(PointsCollected);
                        }
                        break;
                    }
                case "Zombie":
                    {
                        ZombieHealth--;
                        if (ZombieHealth <= 0)
                        {
                            this.gameObject.SetActive(false);
                            PointsCollected += 15;
                            Debug.Log(PointsCollected);
                        }
                        break;
                    }
                case "Drake":
                    {
                        DrakeHealth--;
                        if (DrakeHealth <= 0)
                        {
                            this.gameObject.SetActive(false);
                            PointsCollected += 25;
                            Debug.Log(PointsCollected);
                        }
                        break;
                    }
                case "ExtraPoint":
                    {
                        ShootingBoardHealth--;
                        if (ShootingBoardHealth <= 0)
                        {
                            this.gameObject.SetActive(false);
                            PointsCollected += 10;
                            Debug.Log(PointsCollected);
                        }
                        break;
                    }
            }

        
        if(other.gameObject.tag=="ExtraPoint")
        {
            this.gameObject.SetActive(false);
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mickey")
        {
            Destroy(collision.gameObject);
            Debug.Log("Managed to trigger");
        }
    }*/
}

