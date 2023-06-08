using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Livingroom : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateLight_Livingroom == false)
        {
            moneyCounter.stateLight_Livingroom = true;
            moneyCounter.numLight_Livingroom = 1;
        }
        else if (moneyCounter.stateLight_Livingroom == true)
        {
            moneyCounter.stateLight_Livingroom = false;
            moneyCounter.numLight_Livingroom = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateLight_Livingroom == false)
        {
            moneyCounter.stateLight_Livingroom = true;
            moneyCounter.numLight_Livingroom = 1;
        }
        return true;
    }

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateLight_Livingroom == true)
        {
            moneyCounter.stateLight_Livingroom = false;
            moneyCounter.numLight_Livingroom = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateLight_Livingroom == true && inventory.xRayGoggles == true)
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
