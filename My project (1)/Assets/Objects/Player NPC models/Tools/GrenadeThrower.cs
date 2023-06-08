using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 20f;
    public GameObject grenadePrefab;
    public Inventory inv;

    public float delay = 10f;
    public float countDown;
    public bool readyToThrow = true;

    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToThrow == false)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0f)
            {
                readyToThrow = true;
                countDown = delay;
            }
        }


        if (inv.Teddybear == true && inv.TeddybearUses >= 1 && readyToThrow == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (grenadePrefab != null)
                {
                    inv.TeddybearUses -= 1;
                    readyToThrow = false;
                    ThrowGrenade();
                }

            }
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*throwForce, ForceMode.VelocityChange);
    }
}
