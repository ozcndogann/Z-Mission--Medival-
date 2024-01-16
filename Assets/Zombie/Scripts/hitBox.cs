using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBox : MonoBehaviour
{
    public event Action<int> onDamage;

    [SerializeField] int damageAmount;

    public void TakeDamage()
    {
        onDamage?.Invoke(damageAmount);
    }
}
