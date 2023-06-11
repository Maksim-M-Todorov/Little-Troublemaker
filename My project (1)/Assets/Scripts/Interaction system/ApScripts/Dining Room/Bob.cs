using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;
    public GameObject uiElement;
    public AudioManager audioData;
    private int clipCount = 0;



    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateBob == false)
        {
            moneyCounter.stateBob = true;
            moneyCounter.numBob = 1;
        }
        else if (moneyCounter.stateBob == true)
        {
            moneyCounter.stateBob = false;
            moneyCounter.numBob = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateBob == false)
        {
            moneyCounter.stateBob = true;
            moneyCounter.numBob = 1;
        }
        return true;
    }

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateBob == true)
        {
            moneyCounter.stateBob = false;
            moneyCounter.numBob = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateBob == true && inventory.xRayGoggles == true)
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
        audioData.Play("BobUpgrade");
    }

    private void Update()
    {
        if (moneyCounter.stateBob && Time.timeScale != 0 && (inventory.SolarPanels || inventory.EnergyTiles || inventory.ImprovedIsolation || inventory.LEDBulbs))
        {
            audioData.UnPause("BobUpgrade");
        }
        else
        {
            audioData.Pause("BobUpgrade");
        }

        if (moneyCounter.stateBob && Time.timeScale != 0 && !audioData.isPlaying("BobUpgrade"))
        {
            BobWarning();
        }
    }

    void BobWarning()
    {
        if (moneyCounter.stateBob && Time.timeScale != 0)
        {
            switch (clipCount)
            {
                case 0:
                    if (moneyCounter.stateLight_Bathroom && moneyCounter.stateShower && moneyCounter.stateSink_Bathroom && !audioData.isPlaying("bobBathroom"))
                    {
                        audioData.Play("bobBathroom");
                        uiElement.SetActive(true);
                    }
                    else
                    {
                        if (!audioData.isPlaying("bobBathroom"))
                        {
                            uiElement.SetActive(false);
                            clipCount = 1;
                        }
                    }
                    break;

                case 1:
                    if (moneyCounter.stateLight_Kidsroom && moneyCounter.stateRadiator_Kidsroom && moneyCounter.stateToyTrain && moneyCounter.stateLamp && !audioData.isPlaying("bobKidsroom"))
                    {
                        audioData.Play("bobKidsroom");
                        uiElement.SetActive(true);
                    }
                    else
                    {
                        if (!audioData.isPlaying("bobKidsroom"))
                        {
                            uiElement.SetActive(false);
                            clipCount = 2;
                        }
                    }
                    break;

                case 2:
                    if (moneyCounter.stateBlender && moneyCounter.stateCounter_Dishwasher_Kitchen && moneyCounter.stateCounter_Sink_Kitchen && moneyCounter.stateFridge && moneyCounter.stateMicrowave && moneyCounter.stateStove && moneyCounter.stateLight_Kitchen && !audioData.isPlaying("bobKitchen"))
                    {
                        audioData.Play("bobKitchen");
                        uiElement.SetActive(true);
                    }
                    else
                    {
                        if (!audioData.isPlaying("bobKitchen"))
                        {
                            uiElement.SetActive(false);
                            clipCount = 3;
                        }
                    }
                    break;

                case 3:
                    if (moneyCounter.stateDryer && moneyCounter.stateVacuum && moneyCounter.stateIron && moneyCounter.stateWashingMash && moneyCounter.stateLight_Laundryroom && !audioData.isPlaying("bobLaundryroom"))
                    {
                        audioData.Play("bobLaundryroom");
                        uiElement.SetActive(true);
                    }
                    else
                    {
                        if (!audioData.isPlaying("bobLaundryroom"))
                        {
                            uiElement.SetActive(false);
                            clipCount = 4;
                        }
                    }
                    break;

                case 4:
                    if (moneyCounter.stateGamingSystem && moneyCounter.stateRadio && moneyCounter.stateTV && moneyCounter.stateLight_Livingroom && !audioData.isPlaying("bobLivingroom"))
                    {
                        audioData.Play("bobLivingroom");
                        uiElement.SetActive(true);
                    }
                    else
                    {
                        if (!audioData.isPlaying("bobLivingroom"))
                        {
                            uiElement.SetActive(false);
                            clipCount = 5;
                        }
                    }
                    break;

                case 5:
                    if (moneyCounter.stateIpad && moneyCounter.stateLamp_MasterBedroom && moneyCounter.stateRadiator_MasterBedroom && moneyCounter.stateLight_MasterBedroom && !audioData.isPlaying("bobMasterbedroom"))
                    {
                        audioData.Play("bobMasterbedroom");
                        uiElement.SetActive(true);
                    }
                    else
                    {
                        if (!audioData.isPlaying("bobMasterbedroom"))
                        {
                            uiElement.SetActive(false);
                            clipCount = 0;
                        }
                    }
                    break;
            }
        }
        else
        {
            uiElement.SetActive(false);
        }
    }
}
