using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public MoneyCounter moneyCounter;
    public Inventory inventory;
    public AudioManager audioData;
    public GameObject TVScreen;

    private int clipCount = 0;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (moneyCounter.stateTV == false)
        {
            moneyCounter.stateTV = true;
            moneyCounter.numTV = 1;
        }
        else if (moneyCounter.stateTV == true)
        {
            moneyCounter.stateTV = false;
            moneyCounter.numTV = 0;
        }
        return true;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        if (moneyCounter.stateTV == false)
        {
            moneyCounter.stateTV = true;
            moneyCounter.numTV = 1;
        }
        return true;
    }

    public bool InteractBullet(BulletScript interactor)
    {
        if (moneyCounter.stateTV == true)
        {
            moneyCounter.stateTV = false;
            moneyCounter.numTV = 0;
        }
        return true;
    }
    private void LateUpdate()
    {
        if (moneyCounter.stateTV == true && inventory.xRayGoggles == true)
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
        if (moneyCounter.stateTV)
        {
            TVScreen.SetActive(true);
        }
        else
        {
            TVScreen.SetActive(false);
        }

        PlaySounds();
       
    }
    private void Start()
    {
        audioData.Play("TVFillers");
        audioData.Play("TVSolarPanels");
        audioData.Play("TVPowerGenTiles");
        audioData.Play("TVWallIsolation");
        audioData.Play("LEDBulbs");
    }

    void PlaySounds()
    {
        if (moneyCounter.stateTV == true && Time.timeScale != 0)
        {
            switch (clipCount)
            {
                case 0:
                    if (inventory.SolarPanels == true)
                    {
                        audioData.UnPause("TVSolarPanels");
                        if (!audioData.isPlaying("TVSolarPanels"))
                        {
                            clipCount = 1;
                        }
                    }
                    else
                    {
                        clipCount = 1;
                    }
                    break;

                case 1:
                    if (inventory.EnergyTiles == true)
                    {
                        audioData.UnPause("TVPowerGenTiles");
                        if (!audioData.isPlaying("TVPowerGenTiles"))
                        {
                            clipCount = 2;
                        }
                    }
                    else
                    {
                        clipCount = 2;
                    }
                    break; 
                
                case 2:
                    if (inventory.ImprovedIsolation == true)
                    {
                        audioData.UnPause("TVWallIsolation");
                        if (!audioData.isPlaying("TVWallIsolation"))
                        {
                            clipCount = 3;
                        }
                    }
                    else
                    {
                        clipCount = 3;
                    }
                    break;

                case 3:
                    if (inventory.LEDBulbs == true)
                    {
                        audioData.UnPause("LEDBulbs");
                        if (!audioData.isPlaying("LEDBulbs"))
                        {
                            clipCount = 4;
                        }
                    }
                    else
                    {
                        clipCount = 4;
                    }
                    break;

                case 4:
                    audioData.UnPause("TVFillers");
                    if (!audioData.isPlaying("TVFillers"))
                    {
                        clipCount = 0;
                    }
                    break;
            }
        }
        else
        {
            audioData.Pause("TVFillers");
            audioData.Pause("TVSolarPanels");
            audioData.Pause("TVPowerGenTiles");
            audioData.Pause("TVWallIsolation");
            audioData.Pause("LEDBulbs");
        }
    }
}
