using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using Mono.Cecil.Cil;
using UnityEngine.SceneManagement;

public class MoneyCounter : MonoBehaviour
{
    public TMP_Text mCounterText;
    public Inventory inventory;
    [SerializeField] RoundController roundController;
    public bool counterOn = false;
    public int Delay = 1;
    private float moneyPerSec;
    protected float timer;
    
    //Consumer State var
    [Header("Appliance State")]
    public bool stateWashingMash = false;
    public bool stateDryer = false;
    public bool stateBob = false;
    public bool stateRadio = false;
    public bool stateFridge = false;
    public bool stateTV = false;
    public bool stateLamp = false;


    //Consumer Num ON
    [Header("Appliance State calnum")]
    public int numWashingMash = 0;
    public int numDryer = 0;
    public int numBob = 0;
    public int numRadio = 0;
    public int numFridge = 0;
    public int numTV = 0;
    public int numLamp = 0;
    
    //Consumer Time on
    public int timeWashingMash = 0;
    public int timeDryer = 0;
    public int timeBob = 0;
    public int timeRadio = 0;
    public int timeFridge = 0;
    public int timeTV = 0;
    public int timeLamp = 0;

    //Consumer Cost per Unit
    [Header("Appliance Cost per Second")]
    public int costWashingMash = 20;
    public int costDryer = 45;
    public int costBob = 5;
    public int costRadio = 2;
    public int costFridge = 5;
    public int costTV = 2;
    public int costLamp = 2;


    //Initialize text in the UI element
    private void Start()
    {
        mCounterText.text = inventory.currentMoney.ToString();
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            counterOn = true;
        }
        else { counterOn = false; }
    }

    private void Update()
    {
        //Starts the counter that calculates and adds costs to the total amount.
        if (roundController.roundComplete)
        {
            stateWashingMash = false; 
            stateDryer = false; 
            stateBob = false; 
            stateRadio = false; 
            stateFridge = false; 
            stateTV = false; 
            stateLamp = false;
            counterOn = false; 
        }

        //Counter/Timer
        if (counterOn == true)
        {
            timer += Time.deltaTime;

            if (timer >= Delay)
            {
                timer = 0f;
                MoneyCounterUP();
            }
        }
        mCounterText.text = inventory.currentMoney.ToString();
        SetMoney();
    }

    //Money Calculation + for how long an Appliance is on.
    private void MoneyCounterUP()
    {
        //Count up money collectivly and display it.
        moneyPerSec = (costWashingMash*numWashingMash + costDryer*numDryer + costBob*numBob + costRadio*numRadio + costFridge*numFridge + costTV*numTV + costLamp*numLamp);
        inventory.currentMoney = inventory.currentMoney - (int)moneyPerSec;

        //Count up for how long each appliance is on (Delay Ticks = seconds) used for end of day cost breakup screen.
        timeWashingMash += numWashingMash;
        timeDryer += numDryer;
        timeBob += numBob;
        timeRadio += numRadio;
        timeFridge += numFridge;
        timeTV += numTV;
        timeLamp += numLamp;
    }

    public void SetMoney()
    {
        PlayerPrefs.SetInt("PlayerMoney", inventory.currentMoney);
    }


}
