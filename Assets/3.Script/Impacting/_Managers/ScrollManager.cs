using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    public Transform ItemSpawnParent;  // Spawner에서 할당한 부모 오브젝트 (SpawnItems)
    public Transform ObstacleSpawnParent;
    [Tooltip("Z축 이동속도")] public float scrollSpeed = 5f; // Z축 이동 속도

    private float destroyItem; //아이템 삭제 위치조정

    private Vector3 scrollDirection = Vector3.back; // 카메라 방향으로 움직임 고정(-z축 방향)


    void Start()
    {
        if (Camera.main != null)
        {
            destroyItem = Camera.main.transform.position.z - 5f; //카메라 Z축의 -5 이후 삭제
        }
    }

    void Update()
    {
        MoveItems();
        MoveObstacles();

        DestroyItems();
        DestroyObstacles();
    }

    private void MoveItems()
    {
        if (ItemSpawnParent == null) return;
        foreach (Transform items in ItemSpawnParent)
        {
            if (items != null)
            {
                items.position += scrollDirection * scrollSpeed * Time.deltaTime;
            }
        }
    }

    private void MoveObstacles()
    {
        if (ObstacleSpawnParent == null) return;
        foreach (Transform items in ObstacleSpawnParent)
        {
            if (items != null)
            {
                items.position += scrollDirection * scrollSpeed * Time.deltaTime;
            }
        }
    }


    private void DestroyItems()
    {
        if (ItemSpawnParent == null) return;

        for (int i = ItemSpawnParent.childCount - 1; i >= 0; i--)
        {
            Transform item = ItemSpawnParent.GetChild(i);
            if (item != null && item.position.z <= destroyItem)
            {
                Destroy(item.gameObject);
            }
        }
    }

    private void DestroyObstacles()
    {
        if (ObstacleSpawnParent == null) return;

        for (int i = ObstacleSpawnParent.childCount - 1; i >= 0; i--)
        {
            Transform item = ObstacleSpawnParent.GetChild(i);
            if (item != null && item.position.z <= destroyItem)
            {
                Destroy(item.gameObject);
            }
        }
    }
}