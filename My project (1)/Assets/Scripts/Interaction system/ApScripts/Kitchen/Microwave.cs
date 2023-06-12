using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;
    public AudioSource audioSource;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateMicrowave == false)
        {
            moneyCounter.stateMicrowave = true;
            moneyCounter.numMicrowave = 1;
        }
        else if (moneyCounter.stateMicrowave == true)
        {
            moneyCounter.stateMicrowave = false;
            moneyCounter.numMicrowave = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateMicrowave == false)
        {
            moneyCounter.stateMicrowave = true;
            moneyCounter.numMicrowave = 1;
        }
        return true;
    }

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateMicrowave == true)
        {
            moneyCounter.stateMicrowave = false;
            moneyCounter.numMicrowave = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateMicrowave == true && inventory.xRayGoggles == true)
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
        if(Time.timeScale != 0)
        {
            if (!audioSource.isPlaying && moneyCounter.stateMicrowave)
            {
                audioSource.Play(0);
            }
        }

        if(Time.deltaTime == 0 || moneyCounter.stateMicrowave == false)
        {
            audioSource.Stop();
        }
    }
}
