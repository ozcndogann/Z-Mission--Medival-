using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class Loot : MonoBehaviour
{
    public GameObject uiButton;
    private ThirdPersonShooterController thirdPersonShooterController;
    private StarterAssetsInputs starterAssetsInputs;
    private void Start()
    {
        uiButton.SetActive(false);
        thirdPersonShooterController = GetComponent<ThirdPersonShooterController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Loott();
        }
    }
    void Loott()
    {
        if (test)
        {
            thirdPersonShooterController.arrowCount += 2;
        }
    }
    private bool test;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Chest")
        {
            test = true;
        }
        uiButton.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        uiButton.SetActive(false);
        test = false;
    }
}