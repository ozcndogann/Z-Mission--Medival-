using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using StarterAssets;

public class Zombiee : MonoBehaviour
{
    public int HP = 100;
    public Slider healthBar;
    public Animator animator;
    private Transform player;
    public Transform zombie;
    public GameObject pelvis;
    public static int zombieDieCounter;

    private void Start()
    {
        pelvis.SetActive(true);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        healthBar.value = HP;

        Vector3 zombieForward = zombie.forward.normalized;
        Vector3 zombieToPlayer = player.position.normalized - zombie.position.normalized;

        float dotPro = Vector3.Dot(zombieForward, zombieToPlayer);

        if (!(dotPro <=0.4 && dotPro >= 0) && StarterAssetsInputs.crouch )
        {
            walk.chaseRange = 4;
        }

        //if (animator.GetBehaviour<attack>().test == true)
        //{
        //    pelvis.SetActive(true);
        //}

        //if (animator.GetBehaviour<chasee>().test == true)
        //{
        //    pelvis.SetActive(false);
        //}
        
    }

    [SerializeField] List<hitBox> hitBoxes = new List<hitBox>();
    private void OnEnable()
    {
        foreach (var item in hitBoxes)
        {
            item.onDamage += TakeDamage;
        }
    }

    private void OnDisable()
    {
        foreach (var item in hitBoxes)
        {
            item.onDamage -= TakeDamage;
        }
    }

    

    public void TakeDamage(int damageAmount)
    {
        
        if (HP <= 0)
            return;
        HP -= damageAmount;
        if(HP <= 0)
        {
            animator.SetTrigger("die");
            Destroy(gameObject, 30);
            zombieDieCounter += 1;
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }

    public void GiveDamage()
    {
        player.GetComponent<ThirdPersonShooterController>().TakeDamage();
    }

    
}
