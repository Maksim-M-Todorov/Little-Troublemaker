using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public bool hasKey = false;
    public int startMoney = 2000;
    public int currentMoney = 0;
    

    //Tools
    //==============================================================
    //Teddy Bear
    public bool Teddybear = false;
    int TeddybearUses = 3;

    //Nerf Gun
    public bool NerfGun = false;
    int NerfGunUses = 3;

    //House Keys
    public bool HouseKey = false;
    int HouseKeyUses = 1;

    //Power Outlet Blockers
    public bool PowerOutletBlockers = false;
    int PowerOutletBlockersUses = 3;
    //==============================================================


    //Upgrades
    //==============================================================
    //Solar Panels
    public bool SolarPanels = false;
    //Energy Tiles
    public bool EnergyTiles = false;
    //Improved Isolation
    public bool ImprovedIsolation = false;
    //LED Bulbs
    public bool LEDBulbs = false;
    //==============================================================


    //Appliance Tiers
    //==============================================================
    //Fridge
    public int FridgeTier = 0;
    //Television
    public int TelevisionTier = 0;
    //Oven
    public int OvenTier = 0;
    //Washing Machine
    public int WashingMachineTier = 0;
    //Dryer
    public int DryerTier = 0;
    //==============================================================

    private void Awake()
    {
        currentMoney = PlayerPrefs.GetInt("Money");
    }
    private void Update()
    {
        //if (Keyboard.current.qKey.wasPressedThisFrame) hasKey = !hasKey;
        
    }
}
