using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Toilet : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;
    public AudioSource audioSource;

    bool hasPlayed = false;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateLight_Toilet == false)
        {
            moneyCounter.stateLight_Toilet = true;
            moneyCounter.numLight_Toilet = 1;
        }
        else if (moneyCounter.stateLight_Toilet == true)
        {
            moneyCounter.stateLight_Toilet = false;
            moneyCounter.numLight_Toilet = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateLight_Toilet == false)
        {
            moneyCounter.stateLight_Toilet = true;
            moneyCounter.numLight_Toilet = 1;
        }
        return true;
    }

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateLight_Toilet == true)
        {
            moneyCounter.stateLight_Toilet = false;
            moneyCounter.numLight_Toilet = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateLight_Toilet == true && inventory.xRayGoggles == true)
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
            if (!audioSource.isPlaying && moneyCounter.stateLight_Toilet && !hasPlayed)
            {
                audioSource.Play(0);
                hasPlayed = true;
            }
        }

        if (Time.deltaTime == 0 || moneyCounter.stateLight_Toilet == false)
        {
            audioSource.Stop();
            hasPlayed = false;
        }
    }
}
