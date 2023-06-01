using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kettle : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateKettle == false)
        {
            moneyCounter.stateKettle = true;
            moneyCounter.numKettle = 1;
        }
        else if (moneyCounter.stateKettle == true)
        {
            moneyCounter.stateKettle = false;
            moneyCounter.numKettle = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateKettle == false)
        {
            moneyCounter.stateKettle = true;
            moneyCounter.numKettle = 1;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateKettle == true && inventory.xRayGoggles == true)
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
