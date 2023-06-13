using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyButtonToMainMenu : MonoBehaviour
{
    public LevelChanger levelChanger;
    bool keypressed = false;

    private void Start()
    {
        keypressed = false;
    }

    void Update()
    {
        if (Input.anyKey && !keypressed)
        {
            levelChanger.FadeToMainMenu();
            keypressed = true;
        }
    }
}
