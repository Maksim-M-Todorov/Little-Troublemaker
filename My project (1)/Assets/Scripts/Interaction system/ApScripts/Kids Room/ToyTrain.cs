using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyTrain : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateToyTrain == false)
        {
            moneyCounter.stateToyTrain = true;
            moneyCounter.numToyTrain = 1;
        }
        else if (moneyCounter.stateToyTrain == true)
        {
            moneyCounter.stateToyTrain = false;
            moneyCounter.numToyTrain = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateToyTrain == false)
        {
            moneyCounter.stateToyTrain = true;
            moneyCounter.numToyTrain = 1;
        }
        return true;
    }

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateToyTrain == true)
        {
            moneyCounter.stateToyTrain = false;
            moneyCounter.numToyTrain = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateToyTrain == true && inventory.xRayGoggles == true)
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
