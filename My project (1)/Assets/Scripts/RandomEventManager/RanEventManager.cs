using System.Collections;
using System.Collections.Generic;
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
                }
            break;

        }
    }

    void Update()
    {
        Debug.Log(EventID);
        countDown -= Time.deltaTime;
        if (countDown <= 0f)
        {
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
            }
        }
    }
    int RandomEventDC()
    {
        EventID = Random.Range(1, 6);
        return EventID;
    }
}
