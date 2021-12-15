using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{ 
    public GameObject bullet;
    public GameObject Target;

    public float shootForce, upwardForce;

    public float timeBetweenShooting, spread, timeBetweenShots;

    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot;

    public Transform attackPoint;

    public bool allowInvoke = true;

    private void Awake()
    {
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

    }

    private void MyInput()
    {
        if (readyToShoot&&GameManager.isGameStarted&&!GameManager.isGameEnded&&GameManager.isShootingEnabled)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        Vector3 targetPoint;
        targetPoint = Target.transform.position;
        Vector3 AttackingPoint = attackPoint.transform.position;

        Vector3 directionWithoutSpread = targetPoint - AttackingPoint;

        GameObject currentBullet = ObjectPooler.Instance.SpawnForGameObject("Bullet", AttackingPoint, Quaternion.identity);

        currentBullet.transform.forward = directionWithoutSpread.normalized;

        
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized*shootForce, ForceMode.Impulse);


        
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

        }

        if (true&&GameManager.isShootingEnabled)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
    
}
