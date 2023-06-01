using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink_Toilet : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateSink_Toilet == false)
        {
            moneyCounter.stateSink_Toilet = true;
            moneyCounter.numSink_Toilet = 1;
        }
        else if (moneyCounter.stateSink_Toilet == true)
        {
            moneyCounter.stateSink_Toilet = false;
            moneyCounter.numSink_Toilet = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateSink_Toilet == false)
        {
            moneyCounter.stateSink_Toilet = true;
            moneyCounter.numSink_Toilet = 1;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateSink_Toilet == true && inventory.xRayGoggles == true)
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
