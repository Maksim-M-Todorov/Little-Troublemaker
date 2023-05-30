using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateTV == false)
        {
            moneyCounter.stateTV = true;
            moneyCounter.numTV = 1;
            _prompt = "Switch Off";
        }
        else if (moneyCounter.stateTV == true)
        {
            moneyCounter.stateTV = false;
            moneyCounter.numTV = 0;
            _prompt = "Switch On";
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateTV == false)
        {
            moneyCounter.stateTV = true;
            moneyCounter.numTV = 1;
        }
        return true;
    }
    private void Update()
    {
        if (moneyCounter.stateTV == true && inventory.xRayGoggles == true)
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
