using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class MoneyCounter : MonoBehaviour
{
    public TMP_Text mCounterText;
    public Inventory inventory;
    [SerializeField] RoundController roundController;
    public RanEventManager ranEventManager;
    public bool counterOn = false;
    public int Delay = 1;
    public int moneyPerSec;
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
    #region
    public bool stateSink_Toilet = false;
    public bool stateGamingSystem = false;
    public bool stateKettle = false;
    public bool stateCounter_Sink_Kitchen = false;
    public bool stateCounter_Dishwasher_Kitchen = false;
    public bool stateStove = false;
    public bool stateMicrowave = false;
    public bool stateBlender = false;
    public bool stateIron = false;
    public bool stateVacuum = false;
    public bool stateShower = false;
    public bool stateSink_Bathroom = false;
    public bool stateRadiator_MasterBedroom = false;
    public bool stateIpad = false;
    public bool stateToyTrain = false;
    public bool stateRadiator_Kidsroom = false;
    public bool stateComputer = false;
    public bool stateRadiator_Hall = false;
    public bool stateLamp_MasterBedroom = false;

    public bool stateLight_Entry = false;
    public bool stateLight_Toilet = false;
    public bool stateLight_Livingroom = false;
    public bool stateLight_Diningroom = false;
    public bool stateLight_Kitchen = false;
    public bool stateLight_Laundryroom = false;
    public bool stateLight_Bathroom = false;
    public bool stateLight_MasterBedroom = false;
    public bool stateLight_Kidsroom = false;
    #endregion
    //Consumer Num ON
    [Header("Appliance State calnum")]
    public int numWashingMash = 0;
    public int numDryer = 0;
    public int numBob = 0;
    public int numRadio = 0;
    public int numFridge = 0;
    public int numTV = 0;
    public int numLamp = 0;
    #region
    public int numSink_Toilet = 0;
    public int numGamingSystem = 0;
    public int numKettle = 0;
    public int numCounter_Sink_Kitchen = 0;
    public int numCounter_Dishwasher_Kitchen = 0;
    public int numStove = 0;
    public int numMicrowave = 0;
    public int numBlender = 0;
    public int numIron = 0;
    public int numVacuum = 0;
    public int numShower = 0;
    public int numSink_Bathroom = 0;
    public int numRadiator_MasterBedroom = 0;
    public int numIpad = 0;
    public int numToyTrain = 0;
    public int numRadiator_Kidsroom = 0;
    public int numComputer = 0;
    public int numRadiator_Hall = 0;
    public int numLamp_MasterBedroom = 0;

    public int numLight_Entry = 0;
    public int numLight_Toilet = 0;
    public int numLight_Livingroom = 0;
    public int numLight_Diningroom = 0;
    public int numLight_Kitchen = 0;
    public int numLight_Laundryroom = 0;
    public int numLight_Bathroom = 0;
    public int numLight_MasterBedroom = 0;
    public int numLight_Kidsroom = 0;
    #endregion
    //Consumer Time on
    [Header("Appliance Ticks/Second On")]
    public int timeWashingMash = 0;
    public int timeDryer = 0;
    public int timeBob = 0;
    public int timeRadio = 0;
    public int timeFridge = 0;
    public int timeTV = 0;
    public int timeLamp = 0;
    #region
    public int timeSink_Toilet = 0;
    public int timeGamingSystem = 0;
    public int timeKettle = 0;
    public int timeCounter_Sink_Kitchen = 0;
    public int timeCounter_Dishwasher_Kitchen = 0;
    public int timeStove = 0;
    public int timeMicrowave = 0;
    public int timeBlender = 0;
    public int timeIron = 0;
    public int timeVacuum = 0;
    public int timeShower = 0;
    public int timeSink_Bathroom = 0;
    public int timeRadiator_MasterBedroom = 0;
    public int timeIpad = 0;
    public int timeToyTrain = 0;
    public int timeRadiator_Kidsroom = 0;
    public int timeComputer = 0;
    public int timeRadiator_Hall = 0;
    public int timeLamp_MasterBedroom = 0;

    public int timeLight_Entry = 0;
    public int timeLight_Toilet = 0;
    public int timeLight_Livingroom = 0;
    public int timeLight_Diningroom = 0;
    public int timeLight_Kitchen = 0;
    public int timeLight_Laundryroom = 0;
    public int timeLight_Bathroom = 0;
    public int timeLight_MasterBedroom = 0;
    public int timeLight_Kidsroom = 0;
    #endregion
    //Consumer Cost per Unit
    [Header("Appliance Cost per Second")]
    public int costWashingMash = 10;
    public int costDryer = 20;
    public int costBob = 5;
    public int costRadio = 2;
    public int costFridge = 15;
    public int costTV = 5;
    public int costLamp = 5;
    #region
    public int costSink_Toilet = 2;
    public int costGamingSystem = 10;
    public int costKettle = 5;
    public int costCounter_Sink_Kitchen = 2;
    public int costCounter_Dishwasher_Kitchen = 20;
    public int costStove = 25;
    public int costMicrowave = 15;
    public int costBlender = 5;
    public int costIron = 5;
    public int costVacuum = 5;
    public int costShower = 10;
    public int costSink_Bathroom = 2;
    public int costRadiator_MasterBedroom = 20;
    public int costIpad = 2;
    public int costToyTrain = 2;
    public int costRadiator_Kidsroom = 20;
    public int costComputer = 10;
    public int costRadiator_Hall = 20;
    public int costLamp_MasterBedroom = 5;

    public int costLight_Entry = 5;
    public int costLight_Toilet = 5;
    public int costLight_Livingroom = 5;
    public int costLight_Diningroom = 5;
    public int costLight_Kitchen = 5;
    public int costLight_Laundryroom = 5;
    public int costLight_Bathroom = 5;
    public int costLight_MasterBedroom = 5;
    public int costLight_Kidsroom = 5;
    #endregion

 
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
            stateSink_Toilet = false;
            stateGamingSystem = false;
            stateKettle = false;
            stateCounter_Sink_Kitchen = false;
            stateCounter_Dishwasher_Kitchen = false;
            stateStove = false;
            stateMicrowave = false;
            stateBlender = false;
            stateIron = false;
            stateVacuum = false;
            stateShower = false;
            stateSink_Bathroom = false;
            stateRadiator_MasterBedroom = false;
            stateIpad = false;
            stateToyTrain = false;
            stateRadiator_Kidsroom = false;
            stateComputer = false;
            stateLight_Entry = false;
            stateLight_Toilet = false;
            stateLight_Livingroom = false;
            stateLight_Diningroom = false;
            stateLight_Kitchen = false;
            stateLight_Laundryroom = false;
            stateLight_Bathroom = false;
            stateLight_MasterBedroom = false;
            stateLight_Kidsroom = false;
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

        Debug.Log(roundController.roundCount);
    }


    //Money Calculation + for how long an Appliance is on.
    private void MoneyCounterUP()
    {
        //Count up money collectivly and display it.
        
        inventory.currentMoney = inventory.currentMoney - MoneyPerSec(moneyPerSec);

        //Count up for how long each appliance is on (Delay Ticks = seconds) used for end of day cost breakup screen.
        timeWashingMash += numWashingMash;
        timeDryer += numDryer;
        timeBob += numBob;
        timeRadio += numRadio;
        timeFridge += numFridge;
        timeTV += numTV;
        timeLamp += numLamp;

        timeSink_Toilet += numSink_Toilet;
        timeGamingSystem += numGamingSystem;
        timeKettle += numKettle;
        timeCounter_Sink_Kitchen += numCounter_Sink_Kitchen;
        timeCounter_Dishwasher_Kitchen += numCounter_Dishwasher_Kitchen;
        timeStove += numStove;
        timeMicrowave += numMicrowave;
        timeBlender += numBlender;
        timeIron += numIron;
        timeVacuum += numVacuum;
        timeShower += numShower;
        timeSink_Bathroom += numSink_Bathroom;
        timeRadiator_MasterBedroom += numRadiator_MasterBedroom;
        timeIpad += numIpad;
        timeToyTrain += numToyTrain;
        timeRadiator_Kidsroom += numRadiator_Kidsroom;
        timeComputer += numComputer;
        timeRadiator_Hall += numRadiator_Hall;
        timeLamp_MasterBedroom += numLamp_MasterBedroom;

        timeLight_Entry += numLight_Entry;
        timeLight_Toilet += numLight_Toilet;
        timeLight_Livingroom += numLight_Livingroom;
        timeLight_Diningroom += numLight_Diningroom;
        timeLight_Kitchen += numLight_Kitchen;
        timeLight_Laundryroom += numLight_Laundryroom;
        timeLight_Bathroom += numLight_Bathroom;
        timeLight_MasterBedroom += numLamp_MasterBedroom;
        timeLight_Kidsroom += numLight_Kidsroom;
    }

    //Save and update the money the player has in case of crashes
    public void SetMoney()
    {
        PlayerPrefs.SetInt("PlayerMoney", inventory.currentMoney);
    }

    //Get a number that has to be subtracted from the player each second
    private int MoneyPerSec(double moneyPerSec)
    {
        moneyPerSec = ( costWashingMash * numWashingMash +
                        costDryer * numDryer +
                        costBob * numBob +
                        costRadio * numRadio +
                        costFridge * numFridge +
                        costTV * numTV +
                        costLamp * numLamp +
                        costSink_Toilet * numSink_Toilet +
                        costGamingSystem * numGamingSystem +
                        costKettle * numKettle +
                        costCounter_Sink_Kitchen * numCounter_Sink_Kitchen +
                        costCounter_Dishwasher_Kitchen * numCounter_Dishwasher_Kitchen +
                        costStove * numStove +
                        costMicrowave * numMicrowave +
                        costBlender * numBlender +
                        costIron * numIron +
                        costVacuum * numVacuum +
                        costShower * numShower +
                        costSink_Bathroom * numSink_Bathroom +
                        costRadiator_MasterBedroom * numRadiator_MasterBedroom +
                        costIpad * numIpad +
                        costToyTrain * numToyTrain +
                        costRadiator_Kidsroom * numRadiator_Kidsroom +
                        costComputer * numComputer +
                        costLight_Entry * numLight_Entry +
                        costLight_Toilet * numLight_Toilet +
                        costLight_Livingroom * numLight_Livingroom +
                        costLight_Diningroom * numLight_Diningroom +
                        costLight_Kitchen * numLight_Kitchen +
                        costLight_Laundryroom * numLight_Laundryroom +
                        costLight_Bathroom * numLight_Bathroom +
                        costLight_MasterBedroom * numLight_MasterBedroom +
                        costLight_Kidsroom * numLight_Kidsroom +
                        costRadiator_Hall * numRadiator_Hall +
                        costLamp_MasterBedroom * numLamp_MasterBedroom
                        );
        #region Upgrades and Events
        //Apply House Upgrades
        if (inventory.SolarPanels)
        {
            moneyPerSec *= 0.8;
        }

        if (inventory.EnergyTiles)
        {
            moneyPerSec /= 2;
        }

        if (inventory.ImprovedIsolation)
        {
            costStove = ((costStove * 100)/120);
            costRadiator_Kidsroom = ((costRadiator_Kidsroom * 100) / 120);
            costRadiator_MasterBedroom = ((costRadiator_MasterBedroom * 100) / 120);
            costRadiator_Hall = ((costRadiator_Hall * 100) / 120);
        }

        if (inventory.LEDBulbs)
        {
            costLamp /= 2;
            costLight_Entry /= 2;
            costLight_Toilet /= 2;
            costLight_Livingroom /= 2;
            costLight_Diningroom /= 2;
            costLight_Kitchen /= 2;
            costLight_Laundryroom /= 2;
            costLight_Bathroom /= 2;
            costLight_MasterBedroom /= 2;
            costLight_Kidsroom /= 2;
            costLamp_MasterBedroom /= 2;
        }

        //Appliance Tiers upgrades

        switch (inventory.FridgeTier)
        {
            case 0:
                costFridge = 15;
                break; 
            case 1:
                costFridge = 12;
                break; 
            case 2:
                costFridge = 9;
                break; 
            case 3:
                costFridge = 6;
                break; 
            case 4:
                costFridge = 3;
                break;
        }
        
        switch (inventory.TelevisionTier)
        {
            case 0:
                costTV = 5;
                break; 
            case 1: 
                costTV = 4;
                break; 
            case 2:
                costTV = 3;
                break; 
            case 3:
                costTV = 2;
                break; 
            case 4:
                costTV = 1;
                break;
        }
        
        switch (inventory.StoveTier)
        {
            case 0:
                costStove = 25;
                break; 
            case 1:
                costStove = 20;
                break; 
            case 2:
                costStove = 15;
                break; 
            case 3:
                costStove = 10;
                break; 
            case 4:
                costStove = 5;
                break;
        }
        
        switch (inventory.WashingMachineTier)
        {
            case 0:
                costWashingMash = 10;
                break; 
            case 1:
                costWashingMash = 8;
                break; 
            case 2:
                costWashingMash = 6;
                break; 
            case 3:
                costWashingMash = 4;
                break; 
            case 4:
                costWashingMash = 2;
                break;
        }
        
        switch (inventory.DryerTier)
        {
            case 0:
                costDryer = 20;
                break; 
            case 1:
                costDryer = 16;
                break; 
            case 2:
                costDryer = 12;
                break; 
            case 3:
                costDryer = 8;
                break; 
            case 4:
                costDryer = 4;
                break;
        }
        
        switch (inventory.DishWasherTier)
        {
            case 0:
                costCounter_Dishwasher_Kitchen = 20;
                break; 
            case 1:
                costCounter_Dishwasher_Kitchen = 16;
                break; 
            case 2:
                costCounter_Dishwasher_Kitchen = 12;
                break; 
            case 3:
                costCounter_Dishwasher_Kitchen = 8;
                break; 
            case 4:
                costCounter_Dishwasher_Kitchen = 4;
                break;
        }

        //Events
        if (ranEventManager.EventInflation)
        {
            moneyPerSec *= 1.25;
        }

        if (ranEventManager.EventPowerOutage)
        {
            moneyPerSec *= 0;
        }
        else
        {
            moneyPerSec *= 1;
        }
        #endregion

        return (int)moneyPerSec;
    }
}
