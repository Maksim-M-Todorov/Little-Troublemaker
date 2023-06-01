using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateShower == false)
        {
            moneyCounter.stateShower = true;
            moneyCounter.numShower = 1;
        }
        else if (moneyCounter.stateShower == true)
        {
            moneyCounter.stateShower = false;
            moneyCounter.numShower = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateShower == false)
        {
            moneyCounter.stateShower = true;
            moneyCounter.numShower = 1;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateShower == true && inventory.xRayGoggles == true)
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
