using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public bool hasKey = false;
    public int startMoney = 2000;

    //Passive upgrades

    //Active upgrades

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame) hasKey = !hasKey;
    }
}
