using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UpgradeTiers : MonoBehaviour
{
    public Inventory inv;
    public MoneyCounter mC;
    public GameObject UpTierMenu;
    public GameObject UpTierMenuBFT;
    public GameObject UpTierMenuBTVT;
    public GameObject UpTierMenuBST;
    public GameObject UpTierMenuBWMT;
    public GameObject UpTierMenuBDT;
    public GameObject UpTierMenuBDWT;

    public void FridgeTier()
    {
        inv.FridgeTier ++;
        inv.currentMoney -= 800;
    }
    
    public void TVTier()
    {
        inv.TelevisionTier++;
        inv.currentMoney -= 400;
    }
    
    public void StoveTier()
    {
        inv.StoveTier++;
        inv.currentMoney -= 1200;
    }
    
    public void WashingMashTier()
    {
        inv.WashingMachineTier++;
        inv.currentMoney -= 600;
    }
    
    public void DryerTier()
    {
        inv.DryerTier++;
        inv.currentMoney -= 900;
    }
    
    public void DishwasherTier()
    {
        inv.DishWasherTier++;
        inv.currentMoney -= 700;
    }

    private void Update()
    {
        if (UpTierMenu.activeSelf)
        {
            if (inv.FridgeTier == 4 && UpTierMenuBFT.activeSelf != false) { UpTierMenuBFT.SetActive(false); }
            if (inv.TelevisionTier == 4 && UpTierMenuBTVT.activeSelf != false) { UpTierMenuBTVT.SetActive(false); }
            if (inv.StoveTier == 4 && UpTierMenuBST.activeSelf != false) { UpTierMenuBST.SetActive(false); }
            if (inv.WashingMachineTier == 4 && UpTierMenuBWMT.activeSelf != false) { UpTierMenuBWMT.SetActive(false); }
            if (inv.DryerTier == 4 && UpTierMenuBDT.activeSelf != false) { UpTierMenuBDT.SetActive(false); }
            if (inv.DishWasherTier == 4 && UpTierMenuBDWT.activeSelf != false) { UpTierMenuBDWT.SetActive(false); }
        }
    }

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
