using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    public Transform spawnParent;  // ItemSpawner에서 할당한 부모 오브젝트 (SpawnItems)
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
        DestroyItems();
    }

    private void MoveItems()
    {
        if (spawnParent == null) return;
        foreach (Transform items in spawnParent)
        {
            if (items != null)
            {
                items.position += scrollDirection * scrollSpeed * Time.deltaTime;
            }
        }
    }

    private void DestroyItems()
    {

        if (spawnParent == null) return;


        for (int i = spawnParent.childCount - 1; i >= 0; i--)
        {
            Transform item = spawnParent.GetChild(i);
            if (item != null && item.position.z <= destroyItem)
            {
                Destroy(item.gameObject);
            }
        }

    }
}