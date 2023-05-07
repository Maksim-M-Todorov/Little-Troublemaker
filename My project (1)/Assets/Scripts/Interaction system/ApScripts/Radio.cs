using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateRadio == false)
        {
            moneyCounter.stateRadio = true;
            moneyCounter.numRadio = 1;
            _prompt = "Switch Off";
        }
        else if (moneyCounter.stateRadio == true)
        {
            moneyCounter.stateRadio = false;
            moneyCounter.numRadio = 0;
            _prompt = "Switch On";
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateRadio == false)
        {
            moneyCounter.stateRadio = true;
            moneyCounter.numRadio = 1;
        }
        return true;
    }
}
