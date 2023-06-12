using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerfGunAnimationControllerScript : MonoBehaviour
{
    private Animator nerfGunAnimator;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public Inventory inv;
    public ParticleSystem particle;
    public AudioSource audioSource;
    public float bulletSpeed = 10;

    public float delay = 5f;
    public float countDown;
    public bool readyToFire = true;

    void Start()
    {
        nerfGunAnimator = GetComponent<Animator>();
        countDown = delay;
    }



    void Update()
    {
        if (readyToFire == false)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0f)
            {
                readyToFire = true;
                countDown = delay;
            }
        }

        if (nerfGunAnimator != null)
        {
            if (inv.NerfGun == true && inv.NerfGunUses >= 1 && readyToFire == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    nerfGunAnimator.SetTrigger("Fire");
                    audioSource.Play();
                    var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                    particle.Play();
                    inv.NerfGunUses--;
                    readyToFire = false;
                }
            }
           
        }
    }
}
