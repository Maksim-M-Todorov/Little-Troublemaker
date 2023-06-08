using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateComputer == false)
        {
            moneyCounter.stateComputer = true;
            moneyCounter.numComputer = 1;
        }
        else if (moneyCounter.stateComputer == true)
        {
            moneyCounter.stateComputer = false;
            moneyCounter.numComputer = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateComputer == false)
        {
            moneyCounter.stateComputer = true;
            moneyCounter.numComputer = 1;
        }
        return true;
    }

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateComputer == true)
        {
            moneyCounter.stateComputer = false;
            moneyCounter.numComputer = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateComputer == true && inventory.xRayGoggles == true)
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
