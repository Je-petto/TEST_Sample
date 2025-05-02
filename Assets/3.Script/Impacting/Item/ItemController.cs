using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType { NONE, COIN, HP, }

public class ItemController : MonoBehaviour
{
    public ItemData itemData;
    private Vector3 randomRotationAxis;
    
    void Awake()
    {
        randomRotationAxis = Random.insideUnitSphere.normalized;
        if (randomRotationAxis == Vector3.zero)
            randomRotationAxis = Vector3.up;

        // Debug.Log($"장애물 생성! 회전 축: {randomRotationAxis.x:F2}, {randomRotationAxis.y:F2}, {randomRotationAxis.z:F2}");
    }


    void Update()
    {
        transform.Rotate(randomRotationAxis, itemData.rotationSpeed * Time.deltaTime);

    }


    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {

            if (itemData.it == ItemType.COIN)
            {
                Debug.Log($"ITEM]COIN+{ItemType.COIN}");
            }
            if (itemData.it == ItemType.HP)
            {
                Debug.Log($"ITEM]HP+{ItemType.HP}");
            }
        }
        Destroy(gameObject);
    }
}
