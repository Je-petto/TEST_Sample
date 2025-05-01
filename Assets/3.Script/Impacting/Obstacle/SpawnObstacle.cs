using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
    public Transform spawnObstacle; //생성된 옵스타클 프리팹이 들어갈 부모
    public Camera mainCamera;
    public int spawnZ = 30; //카메라에서 소환될 거리

    public void SpwanObstacle()
    {
        Vector2 randomViewportPos = new Vector2(Random.value, Random.value);

        Vector3 worldPos = mainCamera.ViewportToWorldPoint(new Vector3(randomViewportPos.x, randomViewportPos.y, spawnZ));

        GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];
        Instantiate(prefab, worldPos, Quaternion.identity, spawnObstacle);
    }
}
