using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BreakdownMenu : MonoBehaviour
{
    public TMP_Text invoiceTimeOn;
    public TMP_Text invoiceTotalPerApp;
    public TMP_Text invoiceGrandTotal;
    public MoneyCounter moneyCounter;
    public RoundController roundController;
    public GameObject breakDownMenu;
    public Inventory inventory;

    private int moneyAtRoundStart;
    private int totalMoneyLost;
    private double percentLost;

    private void Start()
    {
        moneyAtRoundStart = inventory.currentMoney;
    }
    private void Update()
    {
        if (roundController.roundComplete)
        {
            breakDownMenu.gameObject.SetActive(true);
            UpdateBreakDownMenuVar();
        }
    }

    void UpdateBreakDownMenuVar()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        invoiceTimeOn.text = (moneyCounter.timeSink_Bathroom + moneyCounter.timeSink_Toilet + moneyCounter.timeCounter_Sink_Kitchen) + "<br>" +
                             moneyCounter.timeRadio + "<br>" +
                             moneyCounter.timeIpad + "<br>" +
                             moneyCounter.timeToyTrain + "<br>" +
                             moneyCounter.timeTV + "<br>" +
                             moneyCounter.timeBob + "<br>" +
                             moneyCounter.timeKettle + "<br>" +
                             moneyCounter.timeBlender + "<br>" +
                             moneyCounter.timeIron + "<br>" +
                             moneyCounter.timeVacuum + "<br>" +
                             (moneyCounter.timeLamp + moneyCounter.timeLamp_MasterBedroom + moneyCounter.timeLight_Bathroom + moneyCounter.timeLight_Diningroom + moneyCounter.timeLight_Entry + moneyCounter.timeLight_Kidsroom + moneyCounter.timeLight_Kitchen + moneyCounter.timeLight_Laundryroom + moneyCounter.timeLight_Livingroom + moneyCounter.timeLight_MasterBedroom + moneyCounter.timeLight_Toilet) + "<br>" +
                             moneyCounter.timeShower + "<br>" +
                             moneyCounter.timeComputer + "<br>" +
                             moneyCounter.timeWashingMash + "<br>" +
                             moneyCounter.timeGamingSystem + "<br>" +
                             moneyCounter.timeMicrowave + "<br>" +
                             moneyCounter.timeFridge + "<br>" +
                             moneyCounter.timeDryer + "<br>" +
                             moneyCounter.timeCounter_Dishwasher_Kitchen + "<br>" +
                             (moneyCounter.timeRadiator_Hall + moneyCounter.timeRadiator_Kidsroom + moneyCounter.timeRadiator_MasterBedroom) + "<br>" +
                             moneyCounter.timeStove;

        invoiceTotalPerApp.text = (moneyCounter.timeSink_Bathroom + moneyCounter.timeSink_Toilet + moneyCounter.timeCounter_Sink_Kitchen) * moneyCounter.costSink_Bathroom + "<br>" +
                             moneyCounter.timeRadio * moneyCounter.costRadio + "<br>" +
                             moneyCounter.timeIpad * moneyCounter.costIpad + "<br>" +
                             moneyCounter.timeToyTrain * moneyCounter.costToyTrain + "<br>" +
                             moneyCounter.timeTV * moneyCounter.costTV + "<br>" +
                             moneyCounter.timeBob * moneyCounter.costBob + "<br>" +
                             moneyCounter.timeKettle * moneyCounter.costKettle + "<br>" +
                             moneyCounter.timeBlender * moneyCounter.costBlender + "<br>" +
                             moneyCounter.timeIron * moneyCounter.costIron + "<br>" +
                             moneyCounter.timeVacuum * moneyCounter.costVacuum + "<br>" +
                             (moneyCounter.timeLamp + moneyCounter.timeLamp_MasterBedroom + moneyCounter.timeLight_Bathroom + moneyCounter.timeLight_Diningroom + moneyCounter.timeLight_Entry + moneyCounter.timeLight_Kidsroom + moneyCounter.timeLight_Kitchen + moneyCounter.timeLight_Laundryroom + moneyCounter.timeLight_Livingroom + moneyCounter.timeLight_MasterBedroom + moneyCounter.timeLight_Toilet) * moneyCounter.costLamp + "<br>" +
                             moneyCounter.timeShower * moneyCounter.costShower + "<br>" +
                             moneyCounter.timeComputer * moneyCounter.costComputer + "<br>" +
                             moneyCounter.timeWashingMash * moneyCounter.costWashingMash + "<br>" +
                             moneyCounter.timeGamingSystem * moneyCounter.costGamingSystem + "<br>" +
                             moneyCounter.timeMicrowave * moneyCounter.costMicrowave + "<br>" +
                             moneyCounter.timeFridge * moneyCounter.costFridge + "<br>" +
                             moneyCounter.timeDryer * moneyCounter.costDryer + "<br>" +
                             moneyCounter.timeCounter_Dishwasher_Kitchen * moneyCounter.costCounter_Dishwasher_Kitchen + "<br>" +
                             (moneyCounter.timeRadiator_Hall + moneyCounter.timeRadiator_Kidsroom + moneyCounter.timeRadiator_MasterBedroom) * moneyCounter.costRadiator_Hall + "<br>" +
                             moneyCounter.timeStove * moneyCounter.costStove;


        totalMoneyLost = ((moneyCounter.timeSink_Bathroom + moneyCounter.timeSink_Toilet + moneyCounter.timeCounter_Sink_Kitchen) * moneyCounter.costSink_Bathroom +
                             moneyCounter.timeRadio * moneyCounter.costRadio +
                             moneyCounter.timeIpad * moneyCounter.costIpad +
                             moneyCounter.timeToyTrain * moneyCounter.costToyTrain +
                             moneyCounter.timeTV * moneyCounter.costTV +
                             moneyCounter.timeBob * moneyCounter.costBob +
                             moneyCounter.timeKettle * moneyCounter.costKettle +
                             moneyCounter.timeBlender * moneyCounter.costBlender +
                             moneyCounter.timeIron * moneyCounter.costIron +
                             moneyCounter.timeVacuum * moneyCounter.costVacuum +
                             (moneyCounter.timeLamp + moneyCounter.timeLamp_MasterBedroom + moneyCounter.timeLight_Bathroom + moneyCounter.timeLight_Diningroom + moneyCounter.timeLight_Entry + moneyCounter.timeLight_Kidsroom + moneyCounter.timeLight_Kitchen + moneyCounter.timeLight_Laundryroom + moneyCounter.timeLight_Livingroom + moneyCounter.timeLight_MasterBedroom + moneyCounter.timeLight_Toilet) * moneyCounter.costLamp +
                             moneyCounter.timeShower * moneyCounter.costShower +
                             moneyCounter.timeComputer * moneyCounter.costComputer +
                             moneyCounter.timeWashingMash * moneyCounter.costWashingMash +
                             moneyCounter.timeGamingSystem * moneyCounter.costGamingSystem +
                             moneyCounter.timeMicrowave * moneyCounter.costMicrowave +
                             moneyCounter.timeFridge * moneyCounter.costFridge +
                             moneyCounter.timeDryer * moneyCounter.costDryer +
                             moneyCounter.timeCounter_Dishwasher_Kitchen * moneyCounter.costCounter_Dishwasher_Kitchen +
                             (moneyCounter.timeRadiator_Hall + moneyCounter.timeRadiator_Kidsroom + moneyCounter.timeRadiator_MasterBedroom) * moneyCounter.costRadiator_Hall +
                             moneyCounter.timeStove * moneyCounter.costStove);

        percentLost = 100 - ((moneyAtRoundStart - inventory.currentMoney) / (totalMoneyLost * 0.01));

        invoiceGrandTotal.text = totalMoneyLost + "<br>" +
                                 "~ " + percentLost.ToString("F1") + "%" + "<br>" +
                                 (moneyAtRoundStart - inventory.currentMoney);
    }
}

