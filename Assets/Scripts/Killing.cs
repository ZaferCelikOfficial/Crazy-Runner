using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killing : MonoBehaviour
{
    public int MickeyHealth=1, ZombieHealth=2, DrakeHealth=3, ShootingBoardHealth=1;
    [SerializeField] int PointsCollected;
    bool isNeverEntered = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if(!isNeverEntered&&isActiveAndEnabled&&GameManager.isShootingEnabled)
        {
            isNeverEntered = true;
            PointsCollected = 0;
        }
        if (other.gameObject.tag == "Bullet"&&isNeverEntered)
            switch(this.gameObject.tag)
            {
                case "Mickey":
                    {
                        MickeyHealth--;
                        if (MickeyHealth <= 0&&isNeverEntered)
                        {
                            isNeverEntered = false;
                            this.gameObject.SetActive(false);
                            PointsCollected = 10;
                            GameManager.instance.PointCounter(PointsCollected);
                        }
                        break;
                    }
                case "Zombie":
                    {
                        ZombieHealth--;
                        if (ZombieHealth <= 0 && isNeverEntered)
                        {
                            isNeverEntered = false;
                            this.gameObject.SetActive(false);
                            PointsCollected = 15;
                            GameManager.instance.PointCounter(PointsCollected);
                        }
                        break;
                    }
                case "Drake":
                    {
                        DrakeHealth--;
                        if (DrakeHealth <= 0 && isNeverEntered)
                        {
                            isNeverEntered = false;
                            this.gameObject.SetActive(false);
                            PointsCollected = 25;
                            GameManager.instance.PointCounter(PointsCollected);
                        }
                        break;
                    }
                case "ExtraPoint":
                    {
                        ShootingBoardHealth--;
                        if (ShootingBoardHealth <=0 && isNeverEntered)
                        {
                            isNeverEntered = false;
                            this.gameObject.SetActive(false);
                            PointsCollected = 10;
                            GameManager.instance.PointCounter(PointsCollected);
                        }
                        break;
                    }
            }
    }
}

