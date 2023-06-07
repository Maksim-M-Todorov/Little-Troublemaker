using UnityEngine;
using UnityEngine.SceneManagement;

public class RanEventManager : MonoBehaviour
{
    int EventID;
    public GameObject kid;
    public GameObject kid2;
    public GameObject kid3;
    public GameObject kid4;
    public Inventory inv;
    public MoneyCounter moneyCounter;

    public GameObject BPEI;
    public GameObject GMI;
    public GameObject WBI;
    public GameObject POI;
    public GameObject IFI;

    public float delay = 30f;
    private float countDown;

    public bool EventInflation = false;
    public bool EventPowerOutage = false;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            RandomEventDC();
        }
    }

    void Start()
    {
        switch (EventID)
        {
            case 1:
                {
                    //Birthday Party, spawn 3 more kids
                    kid2.SetActive(true);
                    kid3.SetActive(true);
                    kid4.SetActive(true);
                    BPEI.SetActive(true);
                    countDown = delay;
                }
            break;

            case 2:
                {
                    //Kid to Grandma, deactivate kid for 30 seconds
                    kid.SetActive(false);
                    countDown = delay;
                    GMI.SetActive(true);
                }
            break;

           //case 3:
           //    {
           //        //Deliver, Go to the door and click E
           //    }
           //break;
                
            case 3:
                {
                    //Work Bonus, get 10k added to current money
                    inv.currentMoney = PlayerPrefs.GetInt("PlayerMoney");
                    inv.currentMoney += 10000;
                    PlayerPrefs.SetInt("PlayerMoney", inv.currentMoney);
                    WBI.SetActive(true);
                    countDown = delay;
                }
            break;
                
            case 4:
                {
                    //Power Outage, set money per sec to 0 for 30 seconds
                    EventPowerOutage = true;
                    countDown = delay;
                    POI.SetActive(true);
                }
            break;
                
            case 5:
                {
                    //Inflation, increase money per sec by 25%
                    EventInflation = true;
                    IFI.SetActive(true);
                    countDown = delay;
                }
            break;

        }
    }

    void Update()
    {
        //Debug.Log(EventID);
        countDown -= Time.deltaTime;
        if (countDown <= 0f)
        {
            if (EventID == 1)
            {
                BPEI.SetActive(false);
            }
            
            if (EventID == 2)
            {
                kid.SetActive(true);
                GMI.SetActive(false);
            }

            if(EventID == 3)
            {
                WBI.SetActive(false);
            }

            if (EventID == 4)
            {
                EventPowerOutage = false;
                POI.SetActive(false);
                EventID = 0;
                moneyCounter.stateWashingMash = false;
                moneyCounter.stateDryer = false;
                moneyCounter.stateBob = false;
                moneyCounter.stateRadio = false;
                moneyCounter.stateFridge = false;
                moneyCounter.stateTV = false;
                moneyCounter.stateLamp = false;
                moneyCounter.stateSink_Toilet = false;
                moneyCounter.stateGamingSystem = false;
                moneyCounter.stateKettle = false;
                moneyCounter.stateCounter_Sink_Kitchen = false;
                moneyCounter.stateCounter_Dishwasher_Kitchen = false;
                moneyCounter.stateStove = false;
                moneyCounter.stateMicrowave = false;
                moneyCounter.stateBlender = false;
                moneyCounter.stateIron = false;
                moneyCounter.stateVacuum = false;
                moneyCounter.stateShower = false;
                moneyCounter.stateSink_Bathroom = false;
                moneyCounter.stateRadiator_MasterBedroom = false;
                moneyCounter.stateIpad = false;
                moneyCounter.stateToyTrain = false;
                moneyCounter.stateRadiator_Kidsroom = false;
                moneyCounter.stateComputer = false;
                moneyCounter.stateLight_Entry = false;
                moneyCounter.stateLight_Toilet = false;
                moneyCounter.stateLight_Livingroom = false;
                moneyCounter.stateLight_Diningroom = false;
                moneyCounter.stateLight_Kitchen = false;
                moneyCounter.stateLight_Laundryroom = false;
                moneyCounter.stateLight_Bathroom = false;
                moneyCounter.stateLight_MasterBedroom = false;
                moneyCounter.stateLight_Kidsroom = false;
                moneyCounter.counterOn = false;
            }

            if (EventID == 5)
            {
                IFI.SetActive(false);
            }
        }
    }
    int RandomEventDC()
    {
        EventID = Random.Range(1, 6);
        return EventID;
    }
}
