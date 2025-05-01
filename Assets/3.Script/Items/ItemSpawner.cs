using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab; // 생성할 아이템 프리팹
    public Transform SpawnItems;
    public Camera mainCamera;
    public int spawnZ = 30; //카메라에서 소환될 거리
    [Tooltip("초(sec)")]public float spawnInterval = 1f; // 스폰 간격 (초)



    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        StartCoroutine(SpawnItemRoutine());
        
    }

   
     private IEnumerator SpawnItemRoutine()
    {
        while (true)
        {
            SpwanItem();
            yield return new WaitForSeconds(spawnInterval);
        }
    }


    private void SpwanItem()
    {

        // 1. 랜덤한 뷰포트 좌표 (화면 내)
        Vector2 randomViewportPos = new Vector2(Random.value, Random.value);

        // 2. Viewport 좌표를 월드 좌표로 변환 (z는 카메라에서의 거리)
        Vector3 worldPos = mainCamera.ViewportToWorldPoint(new Vector3(randomViewportPos.x, randomViewportPos.y, spawnZ));

        // 3. 아이템 생성 프리팹을 부모 오브젝트 밑에 생성
        GameObject spawnedItem = Instantiate(itemPrefab, worldPos, Quaternion.identity, SpawnItems);

    }


}