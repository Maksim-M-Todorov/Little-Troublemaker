using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateIron == false)
        {
            moneyCounter.stateIron = true;
            moneyCounter.numIron = 1;
        }
        else if (moneyCounter.stateIron == true)
        {
            moneyCounter.stateIron = false;
            moneyCounter.numIron = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateIron == false)
        {
            moneyCounter.stateIron = true;
            moneyCounter.numIron = 1;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateIron == true && inventory.xRayGoggles == true)
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
