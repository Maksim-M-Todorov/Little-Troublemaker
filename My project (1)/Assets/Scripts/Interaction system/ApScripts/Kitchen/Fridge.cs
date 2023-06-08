using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateFridge == false)
        {
            moneyCounter.stateFridge = true;
            moneyCounter.numFridge = 1;
            _prompt = "Switch Off";
        }
        else if (moneyCounter.stateFridge == true)
        {
            moneyCounter.stateFridge = false;
            moneyCounter.numFridge = 0;
            _prompt = "Switch On";
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateFridge == false)
        {
            moneyCounter.stateFridge = true;
            moneyCounter.numFridge = 1;
        }
        return true;
    }

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateFridge == true)
        {
            moneyCounter.stateFridge = false;
            moneyCounter.numFridge = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateFridge == true && inventory.xRayGoggles == true)
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
