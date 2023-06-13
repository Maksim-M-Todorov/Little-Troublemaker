using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUReadyMenu : MonoBehaviour
{
    public PauseMenu pauseGame;
    public Inventory inv;
    public PauseMenu pm;

    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Start()
    {
        pauseGame.PauseNoPM();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
            inv.loadPlayerData();
            pm.ResumeNoPM();
        }

        if(gameObject.activeSelf && Time.timeScale == 1)
        {
            gameObject.SetActive(false );
        }
    }
}
