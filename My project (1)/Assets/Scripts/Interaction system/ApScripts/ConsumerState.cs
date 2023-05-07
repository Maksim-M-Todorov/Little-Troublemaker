using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumerState : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.counterOn == false)
        {
            moneyCounter.counterOn = true;
        }
        else
        {
            moneyCounter.counterOn = false;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.counterOn == false)
        {
            moneyCounter.counterOn = true;
        }
        else
        {
            moneyCounter.counterOn = false;
        }
        return true;
    }
}
