using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;

public class MoneyCounter : MonoBehaviour
{
    public TMP_Text mCounterText;
    public Inventory inventory;
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
    private int timeWashingMash = 0;
    private int timeDryer = 0;
    private int timeBob = 0;
    private int timeRadio = 0;
    private int timeFridge = 0;
    private int timeTV = 0;
    private int timeLamp = 0;

    //Consumer Cost per Unit
    [Header("Appliance Cost per Second")]
    [SerializeField]private int costWashingMash = 10;
    [SerializeField]private int costDryer = 10;
    [SerializeField]private int costBob = 10;
    [SerializeField]private int costRadio = 10;
    [SerializeField]private int costFridge = 10;
    [SerializeField]private int costTV = 10;
    [SerializeField]private int costLamp = 10;


    //Initialize text in the UI element
    private void Start()
    {
        mCounterText.text = inventory.startMoney.ToString();
    }

    private void Update()
    {
        //Starts the counter that calculates and adds costs to the total amount.
        if (stateWashingMash == true || stateDryer == true|| stateBob == true|| stateRadio == true|| stateFridge == true|| stateTV == true|| stateLamp == true)
        {
            counterOn = true;
        }
        else { counterOn = false; }

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
    }

    //Money Calculation + for how long an Appliance is on.
    private void MoneyCounterUP()
    {
        //Count up money collectivly and display it.
        moneyPerSec += (costWashingMash*numWashingMash + costDryer*numDryer + costBob*numBob + costRadio*numRadio + costFridge*numFridge + costTV*numTV + costLamp*numLamp);
        mCounterText.text = (inventory.startMoney - (int)moneyPerSec).ToString();

        //Count up for how long each appliance is on (Delay Ticks = seconds) used for end of day cost breakup screen.
        timeWashingMash += numWashingMash;
        timeDryer += numDryer;
        timeBob += numBob;
        timeRadio += numRadio;
        timeFridge += numFridge;
        timeTV += numTV;
        timeLamp += numLamp;
    }


}
