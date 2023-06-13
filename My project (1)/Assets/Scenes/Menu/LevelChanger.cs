using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator Animator;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            FadeToLevel(1);
        }*/
    }

    public void FadeToNextLevel()
    {
        StartCoroutine(FadeToLevel(SceneManager.GetActiveScene().buildIndex+1));
    }
    public void FadeToUpdateMenu()
    {
        StartCoroutine(FadeToLevel(2));
    } 
    public void FadeToMainMenu()
    {
        StartCoroutine(FadeToLevel(0));
    }
    public void FadeToLevel1()
    {
        StartCoroutine(FadeToLevel(1));
    }
    public void FadeToWinScreen()
    {
        StartCoroutine(FadeToLevel(3));
    }
    public void FadeToLoseScreen()
    {
        StartCoroutine(FadeToLevel(4));
    }

    IEnumerator FadeToLevel(int levelIndex)
    {
        Animator.SetTrigger("FadeOut");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
