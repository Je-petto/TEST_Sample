using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObstacleWeight
{
    public GameObject obstaclePrefab;  // 아이템 프리팹
    public int spawnWeight;        // 아이템의 스폰 가중치
    public ObstacleData obstacleData;  // 해당 아이템데이터 정보
}
public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] PlayerBehaviour2 player;
    public List<ObstacleWeight> obstacleDataList; // 각 아이템의 데이터 리스트 
    public Transform spawnObstacle; //생성된 옵스타클 프리팹이 들어갈 부모
    public Camera mainCamera;
    public int spawnZ = 30; //카메라에서 소환될 거리

    public void SpwanObstacle()
    {
        float randomXAxis = Random.Range(player.movementLimits.x, player.movementLimits.width + player.movementLimits.x);
        float randomYAxis = Random.Range(-player.yAxisLimit, player.yAxisLimit);

        Vector3 randomPos = new Vector3(randomXAxis, randomYAxis, spawnZ);


        GameObject prefab = SpawnWieght();
        Instantiate(prefab, randomPos, Quaternion.identity, spawnObstacle);
    }

    private GameObject SpawnWieght()
    {
        //전체 가중치 합 구하기
        int totalWeight = 0; //모든 아이템의 가중치 합계

        foreach (var obstacle in obstacleDataList)
        {
            totalWeight += obstacle.spawnWeight;
        }

        int randomValue = Random.Range(0, totalWeight); //0부터 전체 가중치의 합계
        int currentWeight = 0;

        foreach (var obstacle in obstacleDataList)
        {

            currentWeight += obstacle.spawnWeight;
            if (randomValue < currentWeight)
                return obstacle.obstaclePrefab;
        }

        return obstacleDataList[0].obstaclePrefab; 
    }
}
