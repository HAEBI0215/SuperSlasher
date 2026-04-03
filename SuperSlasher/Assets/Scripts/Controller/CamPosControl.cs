using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPosControl : MonoBehaviour
{
    private Quaternion posControl = Quaternion.identity;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = posControl;
    }
}
