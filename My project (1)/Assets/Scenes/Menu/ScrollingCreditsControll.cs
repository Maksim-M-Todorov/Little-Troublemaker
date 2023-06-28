using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCreditsControll : MonoBehaviour
{
    private float yAxisScroll;
    bool startScrolling = false;

    private void Awake()
    {
        startScrolling = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (startScrolling)
        {
            yAxisScroll += 0.1f;
            transform.position = new Vector3(transform.position.x, yAxisScroll, transform.position.z);
        }
    }

    public void ResetCredits()
    {
        yAxisScroll = 0;
    }
}
