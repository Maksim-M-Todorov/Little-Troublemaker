using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radiator_Masterbedroom : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateRadiator_MasterBedroom == false)
        {
            moneyCounter.stateRadiator_MasterBedroom = true;
            moneyCounter.numRadiator_MasterBedroom = 1;
        }
        else if (moneyCounter.stateRadiator_MasterBedroom == true)
        {
            moneyCounter.stateRadiator_MasterBedroom = false;
            moneyCounter.numRadiator_MasterBedroom = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateRadiator_MasterBedroom == false)
        {
            moneyCounter.stateRadiator_MasterBedroom = true;
            moneyCounter.numRadiator_MasterBedroom = 1;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateRadiator_MasterBedroom == true && inventory.xRayGoggles == true)
        {
            Outline outline = gameObject.GetComponent<Outline>();
            outline.enabled = true;
        }
        else
        {
            Outline outline = gameObject.GetComponent<Outline>();
            outline.enabled = false;
        }
    }
}
