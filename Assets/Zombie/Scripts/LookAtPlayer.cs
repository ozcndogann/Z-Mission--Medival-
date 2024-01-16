using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LookAtPlayer : MonoBehaviour
{
    public Transform cam;
    void LateUpdate()
    {
        transform.LookAt(cam);
    }

}
