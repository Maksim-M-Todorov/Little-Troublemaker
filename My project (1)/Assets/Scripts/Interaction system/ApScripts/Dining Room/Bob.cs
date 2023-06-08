using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateBob == false)
        {
            moneyCounter.stateBob = true;
            moneyCounter.numBob = 1;
        }
        else if (moneyCounter.stateBob == true)
        {
            moneyCounter.stateBob = false;
            moneyCounter.numBob = 0;
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

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateBob == true)
        {
            moneyCounter.stateBob = false;
            moneyCounter.numBob = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateBob == true && inventory.xRayGoggles == true)
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
