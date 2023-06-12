using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter_Sink_Kitchen : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;
    public AudioSource audioSource;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateCounter_Sink_Kitchen == false)
        {
            moneyCounter.stateCounter_Sink_Kitchen = true;
            moneyCounter.numCounter_Sink_Kitchen = 1;
        }
        else if (moneyCounter.stateCounter_Sink_Kitchen == true)
        {
            moneyCounter.stateCounter_Sink_Kitchen = false;
            moneyCounter.numCounter_Sink_Kitchen = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateCounter_Sink_Kitchen == false)
        {
            moneyCounter.stateCounter_Sink_Kitchen = true;
            moneyCounter.numCounter_Sink_Kitchen = 1;
        }
        return true;
    }

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateCounter_Sink_Kitchen == true)
        {
            moneyCounter.stateCounter_Sink_Kitchen = false;
            moneyCounter.numCounter_Sink_Kitchen = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateCounter_Sink_Kitchen == true && inventory.xRayGoggles == true)
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
    private void Update()
    {
        if (Time.timeScale != 0)
        {
            if (!audioSource.isPlaying && moneyCounter.stateCounter_Sink_Kitchen)
            {
                audioSource.Play(0);
            }
        }

        if (Time.deltaTime == 0 || moneyCounter.stateCounter_Sink_Kitchen == false)
        {
            audioSource.Stop();
        }
    }
}
