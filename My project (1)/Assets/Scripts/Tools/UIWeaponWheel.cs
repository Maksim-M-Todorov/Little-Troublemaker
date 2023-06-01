using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIWeaponWheel : MonoBehaviour
{
    public Inventory inv;
    public GrenadeThrower grenadeCD;
    public TMP_Text TBUsesLeft;
    public TMP_Text TBCD;
    public GameObject toolTB;
    public GameObject toolxRG;

    // Update is called once per frame
    void Update()
    {
        if (inv.Teddybear && inv.TeddybearUses >0)
        {
            toolTB.SetActive(true);
        }

        if (inv.xRayGoggles)
        {
            toolxRG.SetActive(true);
        }

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
    }
}
