using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class RoundController : MonoBehaviour
{
    private bool roundStart = false;
    public LevelChanger levelChangerUpgradeMenu;
    public Inventory inventory;
    public GameObject AI;
    public GameObject InteractablesOB;
    public MoneyCounter moneyCounter;
    public PauseMenu pauseMenu;
    public float roundLenght = 120f;
    public bool roundComplete = false;


    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
        { 
        roundStart = true;
        }
        inventory.loadPlayerData();
    }

    void Update()
    {
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
    }
}
