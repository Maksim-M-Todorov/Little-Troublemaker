using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if (inventory.hasKey)
        {
            Debug.Log("Door open");
            return true;
        }

        Debug.Log("No key");
        return false;
    }

    public bool InteractAI(littleTroublemakerMS interactor)
    {
        throw new System.NotImplementedException();
    }
    public bool InteractBullet(BulletScript interactor)
    {
        throw new System.NotImplementedException();
    }
}
