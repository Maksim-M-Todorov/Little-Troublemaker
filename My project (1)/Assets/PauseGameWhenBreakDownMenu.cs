using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameWhenBreakDownMenu : MonoBehaviour
{
    public PauseMenu pauseMenu;

    public Inventory inv;
    public RoundController roundController;
    public LevelChanger levelChanger;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.PauseNoPM();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inv.savePlayerData();
            roundController.AddToRoundCount();
            pauseMenu.ResumeNoPM();
            levelChanger.FadeToUpdateMenu();
        }
    }

}
