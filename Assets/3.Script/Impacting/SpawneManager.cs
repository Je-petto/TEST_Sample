using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawneManager : MonoBehaviour
{


    public SpawnItem spawnItem;
    public SpawnObstacle spawnObstacle;
    private float spawnInterval = 1f; // 기본스폰 간격 (초)
    public float spawnSpeed = 1f; // 숫자가 높아지면 스폰이 많이됨


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
            yield return new WaitForSeconds(spawnInterval / spawnSpeed);
        }
    }







}