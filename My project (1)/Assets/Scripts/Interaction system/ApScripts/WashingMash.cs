using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMash : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateWashingMash == false)
        {
            moneyCounter.stateWashingMash = true;
            moneyCounter.numWashingMash = 1 ;
            _prompt = "Switch Off";
        }
        else if (moneyCounter.stateWashingMash == true)
        {
            moneyCounter.stateWashingMash = false;
            moneyCounter.numWashingMash = 0 ;
            _prompt = "Switch On";
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateWashingMash == false)
        {
            moneyCounter.stateWashingMash = true;
            moneyCounter.numWashingMash = 1;
        }
        return true;
    }
}
