using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dryer : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateDryer == false)
        {
            moneyCounter.stateDryer = true;
            moneyCounter.numDryer = 1;
            _prompt = "Switch Off";
        }
        else if (moneyCounter.stateDryer == true)
        {
            moneyCounter.stateDryer = false;
            moneyCounter.numDryer = 0;
            _prompt = "Switch On";
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateDryer == false)
        {
            moneyCounter.stateDryer = true;
            moneyCounter.numDryer = 1;
        }
        return true;
    }
}
