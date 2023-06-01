using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTools : MonoBehaviour
{
    public Inventory inv;
    public MoneyCounter mC;

    public void TeddyBear()
    {
        inv.Teddybear = true;
        inv.TeddybearUses = 3;
        inv.currentMoney -= 350;
    }

    public void NerfGun()
    {
        inv.NerfGun = true;
        inv.currentMoney -= 250;
    }

    public void EnergyDrink()
    {
        inv.EnergyDrink = true;
        inv.currentMoney -= 400;
    }

    public void xRayGoggles()
    {
        inv.xRayGoggles = true;
        inv.currentMoney -= 300;
    }

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
