using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUReadyMenu : MonoBehaviour
{
    public PauseMenu pauseGame;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        pauseGame.PauseNoPM();
    }
}