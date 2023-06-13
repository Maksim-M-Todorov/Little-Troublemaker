using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TierLetterController : MonoBehaviour
{

    public TMP_Text tierFridgeText;
    public TMP_Text tierTVText;
    public TMP_Text tierStoveText;
    public TMP_Text tierWashingMashText;
    public TMP_Text tierDryerText;
    public TMP_Text tierDishwasherText;

    public Inventory inventory;
 
    // Update is called once per frame
    void Update()
    {
        switch (inventory.FridgeTier)
        {
            case 0:
                tierFridgeText.text = "E";
                break;
            case 1:
                tierFridgeText.text = "D";
                break;
            case 2:
                tierFridgeText.text = "C";
                break;
            case 3:
                tierFridgeText.text = "B";
                break;
            case 4:
                tierFridgeText.text = "A";
                break;
        }

        switch (inventory.TelevisionTier)
        {
            case 0:
                tierTVText.text = "E";
                break;
            case 1:
                tierTVText.text = "D";
                break;
            case 2:
                tierTVText.text = "C";
                break;
            case 3:
                tierTVText.text = "B";
                break;
            case 4:
                tierTVText.text = "A";
                break;
        }

        switch (inventory.StoveTier)
        {
            case 0:
                tierStoveText.text = "E";
                break;
            case 1:
                tierStoveText.text = "D";
                break;
            case 2:
                tierStoveText.text = "C";
                break;
            case 3:
                tierStoveText.text = "B";
                break;
            case 4:
                tierStoveText.text = "A";
                break;
        }

        switch (inventory.WashingMachineTier)
        {
            case 0:
                tierWashingMashText.text = "E";
                break;
            case 1:
                tierWashingMashText.text = "D";
                break;
            case 2:
                tierWashingMashText.text = "C";
                break;
            case 3:
                tierWashingMashText.text = "B";
                break;
            case 4:
                tierWashingMashText.text = "A";
                break;
        }

        switch (inventory.DryerTier)
        {
            case 0:
                tierDryerText.text = "E";
                break;
            case 1:
                tierDryerText.text = "D";
                break;
            case 2:
                tierDryerText.text = "C";
                break;
            case 3:
                tierDryerText.text = "B";
                break;
            case 4:
                tierDryerText.text = "A";
                break;
        }

        switch (inventory.DishWasherTier)
        {
            case 0:
                tierDishwasherText.text = "E";
                break;
            case 1:
                tierDishwasherText.text = "D";
                break;
            case 2:
                tierDishwasherText.text = "C";
                break;
            case 3:
                tierDishwasherText.text = "B";
                break;
            case 4:
                tierDishwasherText.text = "A";
                break;
        }
    }
}
