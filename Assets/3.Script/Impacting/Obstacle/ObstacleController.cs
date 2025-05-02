using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType {NONE, DAMAGE, SCORE, }
public class ObstacleController : MonoBehaviour
{
    public ObstacleData oData;
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
        transform.Rotate(randomRotationAxis, oData.rotationSpeed * Time.deltaTime);
    }



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            if (oData.ot == ObstacleType.DAMAGE)
            {
                Debug.Log($"Obstacle]HP{oData.ot}");

            }
            if (oData.ot == ObstacleType.SCORE)
            {
                Debug.Log($"Obstacle]Score {oData.ot}");
            }
        }
        Destroy(gameObject);
    }
}

