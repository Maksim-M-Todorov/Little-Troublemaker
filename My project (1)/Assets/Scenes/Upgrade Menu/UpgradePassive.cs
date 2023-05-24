using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePassive : MonoBehaviour
{
    public Inventory inv;
    public MoneyCounter mC;

    public void SolarPanels()
    {
        inv.SolarPanels = true;
        inv.currentMoney -= 5000;
    }

    public void EnergyTiles()
    {
        inv.EnergyTiles = true;
        inv.currentMoney -= 9999;
    }

    public void ImprovedIsolation()
    {
        inv.ImprovedIsolation = true;
        inv.currentMoney -= 5000;
    }

    public void LEDBulbs()
    {
        inv.LEDBulbs = true;
        inv.currentMoney -= 1000;
    }

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}

