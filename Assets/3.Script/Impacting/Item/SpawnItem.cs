using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public List<GameObject> itemPrefabs;

    public Transform SpawnItems; //생성된 아이템 프리팹이 들어갈 부모 

    public Camera mainCamera;
    public int spawnZ = 30; //카메라에서 소환될 거리


    public void SpwanItem()
    {

        // 1. 랜덤한 뷰포트 좌표 (화면 내)
        Vector2 randomViewportPos = new Vector2(Random.value, Random.value);

        // 2. Viewport 좌표를 월드 좌표로 변환 (z는 카메라에서의 거리)
        Vector3 worldPos = mainCamera.ViewportToWorldPoint(new Vector3(randomViewportPos.x, randomViewportPos.y, spawnZ));

        // 3. 아이템 생성 프리팹을 부모 오브젝트 밑에 생성
        GameObject prefab = itemPrefabs[Random.Range(0, itemPrefabs.Count)];
        Instantiate(prefab, worldPos, Quaternion.identity, SpawnItems);

    }
}
