using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateStove == false)
        {
            moneyCounter.stateStove = true;
            moneyCounter.numStove = 1;
        }
        else if (moneyCounter.stateStove == true)
        {
            moneyCounter.stateStove = false;
            moneyCounter.numStove = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateStove == false)
        {
            moneyCounter.stateStove = true;
            moneyCounter.numStove = 1;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateStove == true && inventory.xRayGoggles == true)
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
