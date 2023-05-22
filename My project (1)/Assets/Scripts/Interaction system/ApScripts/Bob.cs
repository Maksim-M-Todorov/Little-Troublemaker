using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateBob == false)
        {
            moneyCounter.stateBob = true;
            moneyCounter.numBob = 1;
            _prompt = "Switch Off";
        }
        else if (moneyCounter.stateBob == true)
        {
            moneyCounter.stateBob = false;
            moneyCounter.numBob = 0;
            _prompt = "Switch On";
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateBob == false)
        {
            moneyCounter.stateBob = true;
            moneyCounter.numBob = 1;
        }
        return true;
    }
}
