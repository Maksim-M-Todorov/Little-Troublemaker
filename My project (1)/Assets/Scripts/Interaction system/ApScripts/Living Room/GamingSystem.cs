using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamingSystem : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateGamingSystem == false)
        {
            moneyCounter.stateGamingSystem = true;
            moneyCounter.numGamingSystem = 1;
        }
        else if (moneyCounter.stateGamingSystem == true)
        {
            moneyCounter.stateGamingSystem = false;
            moneyCounter.numGamingSystem = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateGamingSystem == false)
        {
            moneyCounter.stateGamingSystem = true;
            moneyCounter.numGamingSystem = 1;
        }
        return true;
    }
    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateGamingSystem == true)
        {
            moneyCounter.stateGamingSystem = false;
            moneyCounter.numGamingSystem = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateGamingSystem == true && inventory.xRayGoggles == true)
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
