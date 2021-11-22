using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    //bullet 
    public GameObject bullet;
    public GameObject Target;
    AudioSource GameAudioSource;


    //bullet force
    public float shootForce, upwardForce;

    //Gun stats
    public float timeBetweenShooting, spread, timeBetweenShots;

    int bulletsLeft, bulletsShot;

    //Recoil
    //public Rigidbody playerRb;

    //bools
    bool shooting, readyToShoot;

    //Reference
    public Transform attackPoint;

    //Graphics

    //bug fixing :D
    public bool allowInvoke = true;

    private void Awake()
    {
        //make sure magazine is full
        readyToShoot = true;
        GameAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        MyInput();

        //Set ammo display, if it exists :D

    }
    /*void AudioStarter()
    {
        if(readyToShoot && GameManager.isGameStarted && !GameManager.isGameEnded && GameManager.isShootingEnabled)
        {

        }
    }*/
    private void MyInput()
    {
        //Check if allowed to hold down button and take corresponding input
        //if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        //else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Reloading 

        //Reload automatically when trying to shoot without ammo


        //Shooting
        if (readyToShoot&&GameManager.isGameStarted&&!GameManager.isGameEnded&&GameManager.isShootingEnabled)
        {
            if(!GameAudioSource.isPlaying)
        {
                GameAudioSource.Play(0);
            }
            Shoot();
        }
        else if(!GameManager.isShootingEnabled)
        {
            GameAudioSource.Stop();
        }
    }

    private void Shoot()
    {
        
        readyToShoot = false;

        //Find the exact hit position using a raycast
        //Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view
        //RaycastHit hit;

        //check if ray hits something
        Vector3 targetPoint;
        //if (Physics.Raycast(ray, out hit))
        //targetPoint = hit.point;
        //else
        //targetPoint = ray.GetPoint(75); //Just a point far away from the player
        targetPoint = Target.transform.position;
        Vector3 AttackingPoint = attackPoint.transform.position;
        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - AttackingPoint;

        //Calculate spread
        //float x = Random.Range(-spread, spread);
        //float y = Random.Range(-spread, spread);

        //Calculate new direction with spread
        //Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

        //Instantiate bullet/projectile
        ///ObjectPooler.Instance.SpawnForGameObject("Mickey", SpawnArea.transform.position, Quaternion.identity);
        GameObject currentBullet = ObjectPooler.Instance.SpawnForGameObject("Bullet", AttackingPoint, Quaternion.identity); //Instantiate(bullet, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithoutSpread.normalized;

        //Add forces to bullet
        //currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized*shootForce, ForceMode.Impulse);


        //Instantiate muzzle flash, if you have one
        //if (muzzleFlash != null)
        // Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);


        //Invoke resetShot function (if not already invoked), with your timeBetweenShooting
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

            //Add recoil to player (should only be called once)
           //playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
        }

        //if more than one bulletsPerTap make sure to repeat shoot function
        if (true&&GameManager.isShootingEnabled)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        //Allow shooting and invoking again
        readyToShoot = true;
        allowInvoke = true;
    }
    
}
