using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] PlayerBehaviour2 player;
    public List<GameObject> obstaclePrefabs;
    public Transform spawnObstacle; //생성된 옵스타클 프리팹이 들어갈 부모
    public Camera mainCamera;
    public int spawnZ = 30; //카메라에서 소환될 거리

    public void SpwanObstacle()
    {
        float randomXAxis = Random.Range(player.movementLimits.x, player.movementLimits.width + player.movementLimits.x);
        float randomYAxis = Random.Range(-player.yAxisLimit, player.yAxisLimit);

        Vector3 randomPos = new Vector3(randomXAxis, randomYAxis, spawnZ);


        GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];
        Instantiate(prefab, randomPos, Quaternion.identity, spawnObstacle);
    }
}
