using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolGrenade : MonoBehaviour
{
    public float delay = 3f;

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
        Destroy(gameObject);
    }
}
