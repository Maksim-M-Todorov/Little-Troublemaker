using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIWeaponWheel : MonoBehaviour
{
    public Inventory inv;

    public GrenadeThrower grenadeCD;
    public NerfGunAnimationControllerScript fireCD;
    public EnergyDrinkScript energyDrink;

    public TMP_Text TBUsesLeft;
    public TMP_Text TBCD;

    public TMP_Text NGUsesLeft;
    public TMP_Text NGCD;
    
    public TMP_Text EDUsesLeft;
    public TMP_Text EDCD;

    public GameObject toolTB;
    public GameObject toolxRG;
    public GameObject toolNG;
    public GameObject toolED;

    // Update is called once per frame
    void Update()
    {
        //Activete tools wheel UI Icons
        if (inv.Teddybear && inv.TeddybearUses >0)
        {
            toolTB.SetActive(true);
        }
        else
        {
            toolTB.SetActive(false);
        }

        if (inv.xRayGoggles)
        {
            toolxRG.SetActive(true);
        }

        if (inv.NerfGun && inv.NerfGunUses >0)
        {
            toolNG.SetActive(true);
        }
        else 
        { 
            toolNG.SetActive(false); 
        }

        if (inv.EnergyDrink && inv.EnergyDrinkUses >0)
        {
            toolED.SetActive(true);
        }
        else
        {
            toolED.SetActive(false);
        }

        //Display button prompts and cooldown on tools
        if (toolTB != null)
        {
            TBUsesLeft.text = inv.TeddybearUses.ToString();
            if(!grenadeCD.readyToThrow)
            {
                TBCD.text = grenadeCD.countDown.ToShortString(1);
            }
            else
            {
                TBCD.text = "Q";
            }
        }

        if (toolNG != null)
        {
            NGUsesLeft.text = inv.NerfGunUses.ToString();
            if(!fireCD.readyToFire)
            {
                NGCD.text = fireCD.countDown.ToShortString(1);
            }
            else
            {
                NGCD.text = "LMB";
            }
        }

        if (toolED != null)
        {
            EDUsesLeft.text = inv.EnergyDrinkUses.ToString();
            if(!energyDrink.readyToDrink)
            {
                EDCD.text = energyDrink.countDown.ToShortString(1);
            }
            else
            {
                EDCD.text = "RMB";
            }
        }
    }
}
