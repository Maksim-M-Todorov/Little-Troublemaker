using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISCounter_Sink_Kitchen : MonoBehaviour
{
    public GameObject spawnItem;

    public MoneyCounter moneyCounter;
    private bool iconIsDisplaying = false;


    void Update()
    {
        var displayIcon = moneyCounter.stateCounter_Sink_Kitchen;
        if (displayIcon == true && iconIsDisplaying == false)
        {
            Spawn();
            iconIsDisplaying = true;
        }
        else if (displayIcon == false && iconIsDisplaying == true)
        {
            DestroyPreFab();
            iconIsDisplaying = false;
        }

    }

    public void Spawn()
    {
        GameObject newSpawnedObject = Instantiate(spawnItem, transform.position, Quaternion.Euler(-270, 0, 0));
        newSpawnedObject.transform.parent = transform;
    }

    public void DestroyPreFab()
    {
        for (var i = gameObject.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }
}
