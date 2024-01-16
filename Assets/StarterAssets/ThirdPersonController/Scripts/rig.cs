using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;

public class rig : MonoBehaviour
{
    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetInputs;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetInputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (starterAssetInputs.isAiming)
        {
            GetComponent<RigBuilder>().enabled = true;
        }
        else
        {
            GetComponent<RigBuilder>().enabled = false;
        }
    }




}
