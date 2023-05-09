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

    IEnumerator FadeToLevel(int levelIndex)
    {
        Animator.SetTrigger("FadeOut");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
