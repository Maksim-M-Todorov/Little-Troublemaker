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
    [SerializeField] private float roundLenght = 120f;


    void Start()
    {
        roundStart = true;
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
                    levelChangerUpgradeMenu.FadeToUpdateMenu();
                }
            }
        }
    }
}
