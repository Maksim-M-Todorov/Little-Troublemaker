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
        breakdownMenuText.text = "Receipt <br>"
                                 + "WashingMachine: " + moneyCounter.timeWashingMash + " s. * " + moneyCounter.costWashingMash + " €p/s = " + moneyCounter.timeWashingMash * moneyCounter.costWashingMash + "€" + "<br>"
                                 + "Dryer: " + moneyCounter.timeDryer + " s. * " + moneyCounter.costDryer + " €p/s = " + moneyCounter.timeDryer * moneyCounter.costDryer + "€" + "<br>"
                                 + "Fridge: " + moneyCounter.timeFridge + " s. * " + moneyCounter.costFridge + " €p/s = " + moneyCounter.timeFridge * moneyCounter.costFridge + "€" + "<br>"
                                 + "Lamp: " + moneyCounter.timeLamp + " s. * " + moneyCounter.costLamp + " €p/s = " + moneyCounter.timeLamp * moneyCounter.costLamp + "€" + "<br>"
                                 + "Radio: " + moneyCounter.timeRadio + " s. * " + moneyCounter.costRadio + " €p/s = " + moneyCounter.timeRadio * moneyCounter.costRadio + "€" + "<br>"
                                 + "TV: " + moneyCounter.timeTV + " s. * " + moneyCounter.costTV + " €p/s = " + moneyCounter.timeTV * moneyCounter.costTV + "€" + "<br>"
                                 + "Bob: " + moneyCounter.timeBob + " s. * " + moneyCounter.costBob + " €p/s = " + moneyCounter.timeBob * moneyCounter.costBob + "€" + "<br>";

    }
}

