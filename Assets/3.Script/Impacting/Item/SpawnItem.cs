using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemWeight
{
    public GameObject itemPrefab;  // 아이템 프리팹
    public int spawnWeight;        // 아이템의 스폰 가중치
    public ItemData itemData;  // 해당 아이템데이터 정보
}
public class SpawnItem : MonoBehaviour
{
    [SerializeField] PlayerBehaviour2 player;
    public List<ItemWeight> itemDataList; // 각 아이템의 데이터 리스트 
    public Transform SpawnItems; //생성된 아이템 프리팹이 들어갈 부모 
    public Camera mainCamera;
    public int spawnZ = 30; //카메라에서 소환될 거리


    public void SpwanItem()
    {
        float randomXAxis = Random.Range(player.movementLimits.x, player.movementLimits.width + player.movementLimits.x);
        float randomYAxis = Random.Range(-player.yAxisLimit, player.yAxisLimit);

        //Player 이동 반경만큼의 소환 좌표 좌표 (화면 내)
        Vector3 randomPos = new Vector3(randomXAxis, randomYAxis, spawnZ);

        //아이템 생성 프리팹을 부모 오브젝트 밑에 생성
        GameObject selectedPrefab = SpawnWieght();
        Instantiate(selectedPrefab, randomPos, Quaternion.identity, SpawnItems);

    }

    private GameObject SpawnWieght()
    {
        //전체 가중치 합 구하기
        int totalWeight = 0; //모든 아이템의 가중치 합계

        foreach (var item in itemDataList)
        {
           totalWeight += item.spawnWeight;
        }

        int randomValue = Random.Range(0, totalWeight); //0부터 전체 가중치의 합계
        int currentWeight = 0;

        foreach (var item in itemDataList)
        {
            
            currentWeight += item.spawnWeight;
            if (randomValue < currentWeight)
                return item.itemPrefab;
        }

        return itemDataList[0].itemPrefab;
    }
}
