using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameWhenBreakDownMenu : MonoBehaviour
{
    public PauseMenu pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.PauseNoPM();
    }
}
