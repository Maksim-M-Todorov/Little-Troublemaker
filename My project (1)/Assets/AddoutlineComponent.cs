using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddoutlineComponent : MonoBehaviour
{
    private Transform[] childTransform;
    public Inventory inventory;
    private bool outlineScriptAdded = false;
    [SerializeField] private Color outlineColor;
    [SerializeField] private float outlineWidth = 10f;
    [SerializeField] private Outline.Mode outlineMode;

    // Start is called before the first frame update
    void Update()
    {
        if (outlineScriptAdded == false)
        {
            AddOutlineToAppliances();
        }
    }
    public void ActivateOutline(bool appState)
    {
        if (appState == false && inventory.xRayGoggles == true)
        {
            Outline outline = gameObject.GetComponent<Outline>();
            outline.enabled = true;
        }
        else
        {
            Outline outline = gameObject.GetComponent<Outline>();
            outline.enabled = false;
        }
    }

    public void AddOutlineToAppliances()
    {
        {
            List<GameObject> childList = new List<GameObject>();
            childTransform = new Transform[transform.childCount];

            int numOfChild = transform.childCount;
            int i = 0;

            for (i = 0; i < numOfChild; i++)
            {
                childTransform[i] = transform.GetChild(i);
                if (childTransform[i] != transform)
                {
                    childList.Add(childTransform[i].gameObject);
                }
            }
            for (i = 0; i < childList.Count; i++)
            {
                Outline outline = childList[i].AddComponent<Outline>();
                if (outline != null)
                {
                    outline.OutlineMode = outlineMode;
                    outline.OutlineColor = outlineColor;
                    outline.OutlineWidth = outlineWidth;
                }
            }
        }
        outlineScriptAdded = true;
    }
}
