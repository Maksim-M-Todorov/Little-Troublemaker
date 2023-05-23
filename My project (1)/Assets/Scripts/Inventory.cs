using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public bool hasKey = false;
    public int startMoney = 2000;
    public int currentMoney = 0;
    public RoundController roundController;
    

    //Tools
    //==============================================================
    //Teddy Bear
    public bool Teddybear = false;
    int TeddybearUses = 3;

    //Nerf Gun
    public bool NerfGun = false;
    int NerfGunUses = 3;

    //House Keys //SCRAPPED
    public bool HouseKey = false;
    int HouseKeyUses = 1;

    //Power Outlet Blockers
    public bool PowerOutletBlockers = false;
    int PowerOutletBlockersUses = 3;

    //Energy Drink
    public bool EnergyDrink = false;
    int EnergyDrinkUses = 3;
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
    //Tiers goes from 0 to 3 Max
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
    //Dishwasher
    public int DishWasherTier = 0;
    //==============================================================

    private void Awake()
    {
        currentMoney = PlayerPrefs.GetInt("Money");
    }
    private void Update()
    {
        //if (Keyboard.current.qKey.wasPressedThisFrame) hasKey = !hasKey;
    }
    
    //Converts Boolean Variable to an int 1 = true; 0 = false;
    int boolToInt (bool value) { if (value) { return 1; }else { return 0; } }
    //Converts Int to boolean
    bool intToBool (int value) { if (value != 0) { return true; } else { return false; } }

    public void savePlayerData()
    {
        //Save Player Tools
        PlayerPrefs.SetInt("Teddybear", boolToInt(Teddybear));
        PlayerPrefs.SetInt("NerfGun", boolToInt(NerfGun));
        PlayerPrefs.SetInt("EnergyDrink", boolToInt(EnergyDrink));

        //Save Player House Upgrades
        PlayerPrefs.SetInt("SolarPanels", boolToInt(SolarPanels));
        PlayerPrefs.SetInt("EnergyTiles", boolToInt(EnergyTiles));
        PlayerPrefs.SetInt("ImprovedIsolation", boolToInt(ImprovedIsolation));
        PlayerPrefs.SetInt("LEDBulbs", boolToInt(LEDBulbs));

        //Save Player Appliance Tiers
        PlayerPrefs.SetInt("DishWasherTier", DishWasherTier);
        PlayerPrefs.SetInt("DryerTier", DryerTier);
        PlayerPrefs.SetInt("FridgeTier", FridgeTier);
        PlayerPrefs.SetInt("OvenTier", OvenTier);
        PlayerPrefs.SetInt("TelevisionTier", TelevisionTier);
        PlayerPrefs.SetInt("WashingMachineTier", WashingMachineTier);

    }

    public void loadPlayerData()
    {
        //Load Player Tools
        Teddybear = intToBool(PlayerPrefs.GetInt("Teddybear", 0));
        NerfGun = intToBool(PlayerPrefs.GetInt("NerfGun", 0));
        EnergyDrink = intToBool(PlayerPrefs.GetInt("EnergyDrink", 0));

        //Load Player House Upgrades
        SolarPanels = intToBool(PlayerPrefs.GetInt("SolarPanels", 0));
        EnergyTiles = intToBool(PlayerPrefs.GetInt("EnergyTiles", 0));
        ImprovedIsolation = intToBool(PlayerPrefs.GetInt("ImprovedIsolation", 0));
        LEDBulbs = intToBool(PlayerPrefs.GetInt("LEDBulbs", 0));

        //Load Player Appliance Tiers
        DishWasherTier = PlayerPrefs.GetInt("DishWasherTier");
        DryerTier = PlayerPrefs.GetInt("DryerTier");
        FridgeTier = PlayerPrefs.GetInt("FridgeTier");
        OvenTier = PlayerPrefs.GetInt("OvenTier");
        TelevisionTier = PlayerPrefs.GetInt("TelevisionTier");
        WashingMachineTier = PlayerPrefs.GetInt("WashingMachineTier");

    }



}
