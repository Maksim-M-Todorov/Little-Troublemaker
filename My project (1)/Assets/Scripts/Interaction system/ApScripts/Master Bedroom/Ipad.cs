using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ipad : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateIpad == false)
        {
            moneyCounter.stateIpad = true;
            moneyCounter.numIpad = 1;
        }
        else if (moneyCounter.stateIpad == true)
        {
            moneyCounter.stateIpad = false;
            moneyCounter.numIpad = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateIpad == false)
        {
            moneyCounter.stateIpad = true;
            moneyCounter.numIpad = 1;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateIpad == true && inventory.xRayGoggles == true)
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
