using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManagement;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCam;
    [SerializeField] private LayerMask aimColliderMask = new LayerMask();
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform arrow_position;
    [SerializeField] public int arrowCount;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetInputs;
    private ArrowCount _ArrowCount;
    public GameObject cros;
    public Slider healthBar;

    private float gunHeat;
    [SerializeField] public float HP = 100;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetInputs = GetComponent<StarterAssetsInputs>();
        _ArrowCount = GameObject.Find("Canvas").GetComponent<ArrowCount>();
    }

    private void Update()
    {
        healthBar.value = HP;

        arrowCount = Mathf.Clamp(arrowCount, 0, 50);

        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
        {
            mouseWorldPosition = raycastHit.point;
        }

        if (starterAssetInputs.isAiming && thirdPersonController.Grounded && !starterAssetInputs.sprint && arrowCount != 0)
        {
            aimVirtualCam.gameObject.SetActive(true);
            thirdPersonController.SetRotateOnMove(false);

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

            cros.SetActive(true);
        }
        else
        {
            aimVirtualCam.gameObject.SetActive(false);
            thirdPersonController.SetRotateOnMove(true);
            cros.SetActive(false);
        }


        if (arrowCount > 0)
        {
            if (starterAssetInputs.isShooting && starterAssetInputs.isAiming && !starterAssetInputs.sprint)
            {


                if (gunHeat <= 0)
                {
                    gunHeat = 1.8f;  // this is the interval between firing.
                    Vector3 aimDir = (mouseWorldPosition - arrow_position.position).normalized;
                    Instantiate(arrow, mouseWorldPosition, Quaternion.LookRotation(aimDir, Vector3.up));
                    arrowCount--;
                }

                starterAssetInputs.isShooting = false;

                //arrowCount--;
            }
        }

        _ArrowCount.UpdateArrow(arrowCount);

        if (gunHeat > 0)
        {
            gunHeat -= Time.deltaTime;
        }
    }
    public static bool isdead = false;
    public void TakeDamage()
    {
        HP -= Random.Range(3, 7);
        if (HP <= 0)
        {
            thirdPersonController._animator.SetTrigger("isDead");
            isdead = true;
            //SceneManager.LoadScene("Menu");
        }
    }
    
}
