using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public GameObject zombie;
    private int xPos;
    private int zPos;
    private int zombieCount;
    
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (zombieCount < 10)
        {
            xPos = Random.Range(-21, 55);
            zPos = Random.Range(-32, 47);
            Instantiate(zombie, new Vector3(xPos,0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            zombieCount += 1;
        }
    }
}
