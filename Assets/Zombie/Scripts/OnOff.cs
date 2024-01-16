using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOff : MonoBehaviour
{
    public Zombiee zombi;
    public Slider slider;
    public GameObject healthBar;

    private void Start()
    {
        healthBar.SetActive(false);
    }

    void Update()
    {

        if (slider.value != 0 && slider.value < 100)
        {
            healthBar.SetActive(true);
        }

        if (slider.value == 0)
        {
            healthBar.SetActive(false);
        }
    }
}
