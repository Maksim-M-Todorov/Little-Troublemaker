using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter_Dishwasher_Kitchen : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateCounter_Dishwasher_Kitchen == false)
        {
            moneyCounter.stateCounter_Dishwasher_Kitchen = true;
            moneyCounter.numCounter_Dishwasher_Kitchen = 1;
        }
        else if (moneyCounter.stateCounter_Dishwasher_Kitchen == true)
        {
            moneyCounter.stateCounter_Dishwasher_Kitchen = false;
            moneyCounter.numCounter_Dishwasher_Kitchen = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateCounter_Dishwasher_Kitchen == false)
        {
            moneyCounter.stateCounter_Dishwasher_Kitchen = true;
            moneyCounter.numCounter_Dishwasher_Kitchen = 1;
        }
        return true;
    }

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateCounter_Dishwasher_Kitchen == true)
        {
            moneyCounter.stateCounter_Dishwasher_Kitchen = false;
            moneyCounter.numCounter_Dishwasher_Kitchen = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateCounter_Dishwasher_Kitchen == true && inventory.xRayGoggles == true)
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
