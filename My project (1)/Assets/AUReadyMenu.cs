using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUReadyMenu : MonoBehaviour
{
    public PauseMenu pauseGame;
    // Start is called before the first frame update
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
        if (Time.timeScale == 1f)
        {
            gameObject.SetActive(false);
        }
    }
}
