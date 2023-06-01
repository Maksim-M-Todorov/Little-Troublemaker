using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidAnimationControllerScript : MonoBehaviour
{
    private Animator kidAnimator;
    public littleTroublemakerMS littleTroublemakerMS;
    // Start is called before the first frame update
    void Start()
    {
        kidAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (kidAnimator != null)
        {
            if (littleTroublemakerMS._numFound == 0)
            {
                kidAnimator.SetTrigger("Walking");
                kidAnimator.ResetTrigger("Clicking");
            }

            if (littleTroublemakerMS._numFound > 0)
            {
                kidAnimator.SetTrigger("Clicking");
            }

        }
    }
}
