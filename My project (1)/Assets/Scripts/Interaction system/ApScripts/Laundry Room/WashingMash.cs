using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMash : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateWashingMash == false)
        {
            moneyCounter.stateWashingMash = true;
            moneyCounter.numWashingMash = 1 ;
        }
        else if (moneyCounter.stateWashingMash == true)
        {
            moneyCounter.stateWashingMash = false;
            moneyCounter.numWashingMash = 0 ;
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
    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateWashingMash == true)
        {
            moneyCounter.stateWashingMash = false;
            moneyCounter.numWashingMash = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateWashingMash == true && inventory.xRayGoggles == true)
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
