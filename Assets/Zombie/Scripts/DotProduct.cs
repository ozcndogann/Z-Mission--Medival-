using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotProduct : MonoBehaviour
{
    public Transform player;
    public Transform zombie;
    void Update()
    {
        Vector3 zombieForward = zombie.forward;
        Vector3 zombieToPlayer = player.position - zombie.position;

        float dotPro = Vector3.Dot(zombieForward, zombieToPlayer);
    }
}
