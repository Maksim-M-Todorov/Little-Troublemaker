using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour,IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateBlender == false)
        {
            moneyCounter.stateBlender = true;
            moneyCounter.numBlender = 1;
        }
        else if (moneyCounter.stateBlender == true)
        {
            moneyCounter.stateBlender = false;
            moneyCounter.numBlender = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateBlender == false)
        {
            moneyCounter.stateBlender = true;
            moneyCounter.numBlender = 1;
        }
        return true;
    }

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateBlender == true)
        {
            moneyCounter.stateBlender = false;
            moneyCounter.numBlender = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateBlender == true && inventory.xRayGoggles == true)
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
