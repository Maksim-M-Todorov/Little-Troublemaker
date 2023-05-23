using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class RoundController : MonoBehaviour
{
    private bool roundStart = false;
    public LevelChanger levelChangerUpgradeMenu;
    public Inventory inventory;
    public float roundLenght = 120f;
    public bool roundComplete = false;


    void Start()
    {
        roundStart = true;
        //Load Player Data
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
            //Save Player Data *money
            //Display Activate Breakdown Menu
            //If continue button pressed fade level and go to next one
        }
    }
    void StartRound()
    {
        roundStart = true;
    }
}
