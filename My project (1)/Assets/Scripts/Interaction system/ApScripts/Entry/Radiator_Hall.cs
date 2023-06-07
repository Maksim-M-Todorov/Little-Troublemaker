using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radiator_Hall : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateRadiator_Hall == false)
        {
            moneyCounter.stateRadiator_Hall = true;
            moneyCounter.numRadiator_Hall = 1;
        }
        else if (moneyCounter.stateRadiator_Hall == true)
        {
            moneyCounter.stateRadiator_Hall = false;
            moneyCounter.numRadiator_Hall = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateRadiator_Hall == false)
        {
            moneyCounter.stateRadiator_Hall = true;
            moneyCounter.numRadiator_Hall = 1;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateRadiator_Hall == true && inventory.xRayGoggles == true)
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
