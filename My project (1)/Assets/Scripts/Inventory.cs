using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class Inventory : MonoBehaviour
{
    public bool hasKey = false;
    public int startMoney = 20000;
    public int currentMoney = 20000;
    public RoundController roundController;
    

    //Tools
    //==============================================================
    //Teddy Bear
    public bool Teddybear = false;
    public int TeddybearUses = 3;

    //Nerf Gun
    public bool NerfGun = false;
    public int NerfGunUses = 10;

    //Power Outlet Blockers
    public bool xRayGoggles = false;
    //int xRayGogglesUses = 1;

    //Energy Drink
    public bool EnergyDrink = false;
    public int EnergyDrinkUses = 5;
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
    //Stove
    public int StoveTier = 0;
    //Washing Machine
    public int WashingMachineTier = 0;
    //Dryer
    public int DryerTier = 0;
    //Dishwasher
    public int DishWasherTier = 0;
    //==============================================================

    private void Update()
    {
        //if (Keyboard.current.qKey.wasPressedThisFrame) hasKey = !hasKey;
        //Debug.Log(xRayGoggles);
    }
    
    //Converts Boolean Variable to an int 1 = true; 0 = false;
    int boolToInt (bool value) { if (value) { return 1; }else { return 0; } }
    //Converts Int to boolean
    bool intToBool (int value) { if (value != 0) { return true; } else { return false; } }

    public void savePlayerData()
    {
        //Save Player Money
        PlayerPrefs.SetInt("PlayerMoney", currentMoney);

        //Save Player Tools
        PlayerPrefs.SetInt("Teddybear", boolToInt(Teddybear));
        PlayerPrefs.SetInt("TeddybearUses", TeddybearUses);
        PlayerPrefs.SetInt("NerfGun", boolToInt(NerfGun));
        PlayerPrefs.SetInt("NerfGunUses", NerfGunUses);
        PlayerPrefs.SetInt("EnergyDrink", boolToInt(EnergyDrink));
        PlayerPrefs.SetInt("EnergyDrinkUses", EnergyDrinkUses);
        PlayerPrefs.SetInt("xRayGoggles", boolToInt(xRayGoggles));

        //Save Player House Upgrades
        PlayerPrefs.SetInt("SolarPanels", boolToInt(SolarPanels));
        PlayerPrefs.SetInt("EnergyTiles", boolToInt(EnergyTiles));
        PlayerPrefs.SetInt("ImprovedIsolation", boolToInt(ImprovedIsolation));
        PlayerPrefs.SetInt("LEDBulbs", boolToInt(LEDBulbs));

        //Save Player Appliance Tiers
        PlayerPrefs.SetInt("DishWasherTier", DishWasherTier);
        PlayerPrefs.SetInt("DryerTier", DryerTier);
        PlayerPrefs.SetInt("FridgeTier", FridgeTier);
        PlayerPrefs.SetInt("StoveTier", StoveTier);
        PlayerPrefs.SetInt("TelevisionTier", TelevisionTier);
        PlayerPrefs.SetInt("WashingMachineTier", WashingMachineTier);

    }

    public void loadPlayerData()
    {
        //Load Player Money
        currentMoney = PlayerPrefs.GetInt("PlayerMoney");

        //Load Player Tools
        Teddybear = intToBool(PlayerPrefs.GetInt("Teddybear", 0));
        TeddybearUses = PlayerPrefs.GetInt("TeddybearUses");
        NerfGun = intToBool(PlayerPrefs.GetInt("NerfGun", 0));
        NerfGunUses = PlayerPrefs.GetInt("NerfGunUses");
        EnergyDrink = intToBool(PlayerPrefs.GetInt("EnergyDrink", 0));
        EnergyDrinkUses = PlayerPrefs.GetInt("EnergyDrinkUses");
        xRayGoggles = intToBool(PlayerPrefs.GetInt("xRayGoggles", 0));

        //Load Player House Upgrades
        SolarPanels = intToBool(PlayerPrefs.GetInt("SolarPanels", 0));
        EnergyTiles = intToBool(PlayerPrefs.GetInt("EnergyTiles", 0));
        ImprovedIsolation = intToBool(PlayerPrefs.GetInt("ImprovedIsolation", 0));
        LEDBulbs = intToBool(PlayerPrefs.GetInt("LEDBulbs", 0));

        //Load Player Appliance Tiers
        DishWasherTier = PlayerPrefs.GetInt("DishWasherTier");
        DryerTier = PlayerPrefs.GetInt("DryerTier");
        FridgeTier = PlayerPrefs.GetInt("FridgeTier");
        StoveTier = PlayerPrefs.GetInt("StoveTier");
        TelevisionTier = PlayerPrefs.GetInt("TelevisionTier");
        WashingMachineTier = PlayerPrefs.GetInt("WashingMachineTier");

    }

    public void clearPlayerData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void setStarterMoney()
    {
        currentMoney = startMoney;
        PlayerPrefs.SetInt("PlayerMoney", currentMoney);
    }
}
