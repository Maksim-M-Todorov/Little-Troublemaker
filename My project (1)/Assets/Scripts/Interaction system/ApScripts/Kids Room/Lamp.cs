using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateLamp == false)
        {
            moneyCounter.stateLamp = true;
            moneyCounter.numLamp = 1;
            _prompt = "Switch Off";
        }
        else if (moneyCounter.stateLamp == true)
        {
            moneyCounter.stateLamp = false;
            moneyCounter.numLamp = 0;
            _prompt = "Switch On";
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateLamp == false)
        {
            moneyCounter.stateLamp = true;
            moneyCounter.numLamp = 1;
        }
        return true;
    }

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateLamp == true)
        {
            moneyCounter.stateLamp = false;
            moneyCounter.numLamp = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateLamp == true && inventory.xRayGoggles == true)
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
