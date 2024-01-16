using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CloseTheDoor : MonoBehaviour
{
    public GameObject uiButton;
    public GameObject theDoor;
    private ThirdPersonShooterController thirdPersonShooterController;
    private StarterAssetsInputs starterAssetsInputs;
    private void Start()
    {
        uiButton.SetActive(false);
        thirdPersonShooterController = GetComponent<ThirdPersonShooterController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();

    }
    private bool test;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Close();
        }
    }

   
    private void Close()
    {
        theDoor.transform.Rotate(0, 40, 0);
        test = true;
    }

    private void OnTriggerStay(Collider other)
    {
        uiButton.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        uiButton.SetActive(false);
    }
}
