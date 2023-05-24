using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BreakdownMenu : MonoBehaviour
{
    public TMP_Text breakdownMenuText;
    public MoneyCounter moneyCounter;
    public RoundController roundController;
    public GameObject breakDownMenu;

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
        breakdownMenuText.text = "Breakdown <br>"
                                 + "WashingMachine: " + moneyCounter.timeWashingMash + " * " + moneyCounter.costWashingMash + " = " + moneyCounter.timeWashingMash * moneyCounter.costWashingMash + "€" + "<br>"
                                 + "Dryer: " + moneyCounter.timeDryer + " * " + moneyCounter.costDryer + " = " + moneyCounter.timeDryer * moneyCounter.costDryer + "€" + "<br>"
                                 + "Fridge: " + moneyCounter.timeFridge + " * " + moneyCounter.costFridge + " = " + moneyCounter.timeFridge * moneyCounter.costFridge + "€" + "<br>"
                                 + "Lamp: " + moneyCounter.timeLamp + " * " + moneyCounter.costLamp + " = " + moneyCounter.timeLamp * moneyCounter.costLamp + "€" + "<br>"
                                 + "Radio: " + moneyCounter.timeRadio + " * " + moneyCounter.costRadio + " = " + moneyCounter.timeRadio * moneyCounter.costRadio + "€" + "<br>"
                                 + "TV: " + moneyCounter.timeTV + " * " + moneyCounter.costTV + " = " + moneyCounter.timeTV * moneyCounter.costTV + "€" + "<br>"
                                 + "Bob: " + moneyCounter.timeBob + " * " + moneyCounter.costBob + " = " + moneyCounter.timeBob * moneyCounter.costBob + "€" + "<br>";

    }
}

