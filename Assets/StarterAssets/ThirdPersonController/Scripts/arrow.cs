using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public void Start()
    {
        Destroy(gameObject, 10);
    }
  
    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.GetComponent<Rigidbody>());

        if (other.tag == "ZombiBody")
        {
            transform.parent = other.transform;

            if (!other.TryGetComponent<hitBox>(out hitBox box))
                return;

            box.TakeDamage();
        }
    }
}
