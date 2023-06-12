using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherVoiceControlls : MonoBehaviour
{
    float delay = 8;
    float countdown;
    bool speaking = false;

    public AudioManager audioData;
    
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (speaking == false)
            {
                countdown -= Time.deltaTime;
                if (countdown <= 0)
                {
                    speaking = true;
                    countdown = delay;
                    int saywhat = Random.Range(0, 4);
                    switch (saywhat)
                    {
                        case 0:
                            if (!audioData.isPlaying("noRunning") && !audioData.isPlaying("sigh") && !audioData.isPlaying("stop") && !audioData.isPlaying("timeout"))
                            {
                                audioData.Play("noRunning");
                                speaking = false;
                            }
                            break;

                        case 1:
                            if (!audioData.isPlaying("noRunning") && !audioData.isPlaying("sigh") && !audioData.isPlaying("stop") && !audioData.isPlaying("timeout"))
                            {
                                audioData.Play("sigh");
                                speaking = false;
                            }
                            break;
                            
                        case 2:
                            if (!audioData.isPlaying("noRunning") && !audioData.isPlaying("sigh") && !audioData.isPlaying("stop") && !audioData.isPlaying("timeout"))
                            {
                                audioData.Play("stop");
                                speaking = false;
                            }
                            break;
                            
                        case 3:
                            if (!audioData.isPlaying("noRunning") && !audioData.isPlaying("sigh") && !audioData.isPlaying("stop") && !audioData.isPlaying("timeout"))
                            {
                                audioData.Play("timeout");
                                speaking = false;
                            }
                            break;

                    }
                }
            }
        }
        else
        {
            audioData.Stop("noRunning");
            audioData.Stop("sigh");
            audioData.Stop("stop");
            audioData.Stop("timeout");
        }
    }
}
