using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowCount : MonoBehaviour
{
    [SerializeField] private Text arrowText;
    
    public void UpdateArrow(int count)
    {
        arrowText.text = count + "/50";
    }
}
