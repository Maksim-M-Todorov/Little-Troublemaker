using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsHolderControls : MonoBehaviour
{
    public Inventory inv;

    public GameObject nerfgun;
    public GameObject energydrink;

    // Update is called once per frame
    void Update()
    {
        if (inv.NerfGun && inv.NerfGunUses > 0)
        {
            nerfgun.SetActive(true);
        }
        else
        {
            nerfgun.SetActive(false);
        }
        
        if (inv.EnergyDrink && inv.EnergyDrinkUses > 0)
        {
            energydrink.SetActive(true);
        }
        else
        {
            energydrink.SetActive(false);
        }
    }
}
