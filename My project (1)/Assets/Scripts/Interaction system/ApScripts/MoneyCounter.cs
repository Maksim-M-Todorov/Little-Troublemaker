using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;

public class MoneyCounter : MonoBehaviour
{
    public TMP_Text mCounterText;
    private float moneyPerSec;
    public int Delay = 1;
    protected float timer;
    public bool counterOn = false;

    //Consumer State var
    public bool stateWashingMash = false;
    public bool stateDryer = false;
    public bool stateBob = false;
    public bool stateRadio = false;
    public bool stateFridge = false;
    public bool stateTV = false;
    public bool stateLamp = false;


    //Consumer Num ON
    public int numWashingMash = 0;
    public int numDryer = 0;
    public int numBob = 0;
    public int numRadio = 0;
    public int numFridge = 0;
    public int numTV = 0;
    public int numLamp = 0;

    //Consumer Cost per Unit
    public int costWashingMash = 10;
    public int costDryer = 10;
    public int costBob = 10;
    public int costRadio = 10;
    public int costFridge = 10;
    public int costTV = 10;
    public int costLamp = 10;



    private void Start()
    {
        mCounterText.text = "";
    }

    private void Update()
    {
        if (stateWashingMash == true || stateDryer == true|| stateBob == true|| stateRadio == true|| stateFridge == true|| stateTV == true|| stateLamp == true)
        {
            counterOn = true;
        }
        else { counterOn = false; }



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

    public void MoneyCounterUP()
    {

        moneyPerSec += (costWashingMash*numWashingMash + costDryer*numDryer + costBob*numBob + costRadio*numRadio + costFridge*numFridge + costTV*numTV + costLamp*numLamp);
        mCounterText.text = "-" + (int)moneyPerSec;
    }

}
