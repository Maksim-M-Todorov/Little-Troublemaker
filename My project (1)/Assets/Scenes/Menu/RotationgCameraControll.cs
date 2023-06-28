using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationgCameraControll : MonoBehaviour
{
    private float rotation;

    void Update()
    {
        rotation += 0.01f;
        transform.rotation = Quaternion.Euler(new Vector3(0f, rotation, 0f));
    }
}
