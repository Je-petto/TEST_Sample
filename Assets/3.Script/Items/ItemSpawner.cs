using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab; // 생성할 아이템 프리팹
    public Camera mainCamera;
    public float spawnZ;



    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        SpwanItem();
    }


    void SpwanItem()
    {

           // 1. 랜덤한 뷰포트 좌표 (화면 내)
        Vector2 randomViewportPos = new Vector2(Random.value, Random.value);

        // 2. Viewport 좌표를 월드 좌표로 변환 (z는 카메라에서의 거리)
        Vector3 worldPos = mainCamera.ViewportToWorldPoint(new Vector3(randomViewportPos.x, randomViewportPos.y, spawnZ));

        // 3. 아이템 생성
        Instantiate(itemPrefab, worldPos, Quaternion.identity);

    }


}