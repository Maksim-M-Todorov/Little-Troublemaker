using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrinkScript : MonoBehaviour
{
    public Inventory inv;
    public PlayerMovement playerSpeed;

    public float delay = 5f;
    public float countDown;
    public bool readyToDrink = true;

    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToDrink == false)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0f)
            {
                readyToDrink = true;
                playerSpeed.moveSpeed = 7f;
                countDown = delay;
            }
        }

        if (inv.EnergyDrink == true && inv.EnergyDrinkUses >= 1 && readyToDrink == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                playerSpeed.moveSpeed = 12f;
                readyToDrink = false;
                inv.EnergyDrinkUses--;
            }
        }
    }
}
