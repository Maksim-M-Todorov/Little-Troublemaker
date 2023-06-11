using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class Radio : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;
    public RoundController roundController;

    public AudioSource day0Audio;
    public AudioSource day1Audio;
    public AudioSource day2Audio;
    public AudioSource day3Audio;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateRadio == false)
        {
            moneyCounter.stateRadio = true;
            moneyCounter.numRadio = 1;
            _prompt = "Switch Off";
        }
        else if (moneyCounter.stateRadio == true)
        {
            moneyCounter.stateRadio = false;
            moneyCounter.numRadio = 0;
            _prompt = "Switch On";
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateRadio == false)
        {
            moneyCounter.stateRadio = true;
            moneyCounter.numRadio = 1;
        }
        return true;
    }

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateRadio == true)
        {
            moneyCounter.stateRadio = false;
            moneyCounter.numRadio = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateRadio == true && inventory.xRayGoggles == true)
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
    private void Start()
    {
        day0Audio.Play(0);
        day1Audio.Play(0);
        day2Audio.Play(0);
        day3Audio.Play(0);
    }
    private void Update()
    {
        if (moneyCounter.stateRadio && Time.timeScale != 0)
        {
            switch (roundController.roundCount)
            {
                case 0:
                    day0Audio.UnPause();
                break;

                case 1:
                    day1Audio.UnPause();
                break;

                case 2:
                    day2Audio.UnPause();
                break;

                case 3:
                    day3Audio.UnPause();
                break;
            }
        }
        else
        {
            day0Audio.Pause();
            day1Audio.Pause();
            day2Audio.Pause();
            day3Audio.Pause();
        }
    }
}
