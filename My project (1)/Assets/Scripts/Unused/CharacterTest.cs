using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTest : MonoBehaviour
{
    bool isAlive = true;
    int charMaxHealth = 100;
    int charCurrentHealth = 50;

    // Start is called before the first frame update
    void Start()
    {
        int charBonusHealth = 20;
        charCurrentHealth += charBonusHealth;
        Debug.Log(charCurrentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
