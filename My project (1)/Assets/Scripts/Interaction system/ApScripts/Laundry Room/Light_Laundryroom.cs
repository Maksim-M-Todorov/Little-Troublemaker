using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Laundryroom : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;
    public AudioSource audioSource;

    bool hasPlayed = false;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateLight_Laundryroom == false)
        {
            moneyCounter.stateLight_Laundryroom = true;
            moneyCounter.numLight_Laundryroom = 1;
        }
        else if (moneyCounter.stateLight_Laundryroom == true)
        {
            moneyCounter.stateLight_Laundryroom = false;
            moneyCounter.numLight_Laundryroom = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateLight_Laundryroom == false)
        {
            moneyCounter.stateLight_Laundryroom = true;
            moneyCounter.numLight_Laundryroom = 1;
        }
        return true;
    }

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateLight_Laundryroom == true)
        {
            moneyCounter.stateLight_Laundryroom = false;
            moneyCounter.numLight_Laundryroom = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateLight_Laundryroom == true && inventory.xRayGoggles == true)
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
            if (!audioSource.isPlaying && moneyCounter.stateLight_Laundryroom && !hasPlayed)
            {
                audioSource.Play(0);
                hasPlayed = true;
            }
        }

        if (Time.deltaTime == 0 || moneyCounter.stateLight_Laundryroom == false)
        {
            audioSource.Stop();
            hasPlayed = false;
        }
    }
}
