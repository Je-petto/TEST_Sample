using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public SpawnItem spawnItem;
    public SpawnObstacle spawnObstacle;
    [Tooltip("초(sec)")] public float spawnInterval = 1f; // 스폰 간격 (초)


    void Start()
    {        
        StartCoroutine(SpawnItemRoutine());
    }
    private IEnumerator SpawnItemRoutine()
    {
        while (true)
        {
            spawnItem.SpwanItem();
            spawnObstacle.SpwanObstacle();
            yield return new WaitForSeconds(spawnInterval);
        }
    }


 

    


}