using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink_Bathroom : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;
    public AudioSource audioSource;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateSink_Bathroom == false)
        {
            moneyCounter.stateSink_Bathroom = true;
            moneyCounter.numSink_Bathroom = 1;
        }
        else if (moneyCounter.stateSink_Bathroom == true)
        {
            moneyCounter.stateSink_Bathroom = false;
            moneyCounter.numSink_Bathroom = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateSink_Bathroom == false)
        {
            moneyCounter.stateSink_Bathroom = true;
            moneyCounter.numSink_Bathroom = 1;
        }
        return true;
    }

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateSink_Bathroom == true)
        {
            moneyCounter.stateSink_Bathroom = false;
            moneyCounter.numSink_Bathroom = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateSink_Bathroom == true && inventory.xRayGoggles == true)
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
            if (!audioSource.isPlaying && moneyCounter.stateSink_Bathroom)
            {
                audioSource.Play(0);
            }
        }

        if (Time.deltaTime == 0 || moneyCounter.stateSink_Bathroom == false)
        {
            audioSource.Stop();
        }
    }
}
