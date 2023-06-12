using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolGrenade : MonoBehaviour
{
    public float delay = 3f;
    public float blastRadius = 5f;
    public float force = 700f;

    float countDown;
    bool hasExploded = false;

    public GameObject explosionEffect;


    // Start is called before the first frame update
    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null )
            {
                rb.AddExplosionForce(force, transform.position, blastRadius);
            }
        }

        Destroy(gameObject);
    }
}
