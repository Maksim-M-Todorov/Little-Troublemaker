using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundController : MonoBehaviour
{
    private bool roundStart = false;
    public LevelChanger levelChangerUpgradeMenu;
    public Inventory inventory;
    public GameObject AI;
    public GameObject InteractablesOB;
    public MoneyCounter moneyCounter;
    public PauseMenu pauseMenu;
    public TMP_Text roundClock;
    public float roundLenght = 120f;
    public bool roundComplete = false;
    public int roundCount = 0;


    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
        { 
            roundStart = true;
        }
        inventory.loadPlayerData();
        roundCount = PlayerPrefs.GetInt("RoundsPlayed");
    }

    void Update()
    {
        //Debug.Log(roundCount);
        if (roundStart == true)
        {
            if (roundLenght > 0f)
            {
                roundLenght -= Time.deltaTime;
            }
            else
            {
                roundLenght = 0f;
                if (inventory.startMoney > 0)
                {
                    roundComplete = true;
                    //levelChangerUpgradeMenu.FadeToUpdateMenu();
                }
            }
        }

        if (roundComplete == true)
        {
            AI.gameObject.SetActive(false);
            InteractablesOB.gameObject.SetActive(false);
            inventory.savePlayerData();
            //Save Player Data *money
            //Display Activate Breakdown Menu
            //If continue button pressed fade level and go to next one
        }

        if (roundClock != null)
        {
            roundClock.text = ((int)roundLenght).ToString();
        }
    }

    public void AddToRoundCount()
    {
        roundCount++;
        PlayerPrefs.SetInt("RoundsPlayed", roundCount);
    }

}
