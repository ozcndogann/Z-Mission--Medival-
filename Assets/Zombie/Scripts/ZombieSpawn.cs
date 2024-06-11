using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public GameObject zombie,stage2zombie,stage3zombie;
    private int xPos;
    private int zPos;
    private int zombieCount;
    private int stageInt=2;
    
    void Start()
    {
        StartCoroutine(Spawn());
    }
    private void Update()
    {

        if (StageScript.StageCounter == 2 && stageInt == 2)
        {
            zombieCount = 0;
            StartCoroutine(SpawnStage2());
            stageInt++;
        }
        else if (StageScript.StageCounter == 3 && stageInt == 3)
        {
            zombieCount = 0;
            StartCoroutine(SpawnStage3());
            stageInt++;
        }
    }
    IEnumerator Spawn()
    {
        while (zombieCount < StageScript.StageCounter * 5)
        {
            xPos = Random.Range(-21, 55);
            zPos = Random.Range(-32, 47);
            Instantiate(zombie, new Vector3(xPos,0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            zombieCount += 1;
        }
    }
    IEnumerator SpawnStage2()
    {
        while (zombieCount < StageScript.StageCounter * 5)
        {
            xPos = Random.Range(-21, 55);
            zPos = Random.Range(-32, 47);
            Instantiate(stage2zombie, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            zombieCount += 1;
        }
    }
    IEnumerator SpawnStage3()
    {
        while (zombieCount < StageScript.StageCounter * 5)
        {
            xPos = Random.Range(-21, 55);
            zPos = Random.Range(-32, 47);
            Instantiate(stage3zombie, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            zombieCount += 1;
        }
    }
}
