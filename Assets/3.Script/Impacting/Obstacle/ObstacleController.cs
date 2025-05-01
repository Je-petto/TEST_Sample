using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public ObstacleData oData;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            if (oData.ot == ObstacleType.TEMP1)
            {
                Debug.Log("Obstacle]TEMP1");
            }
            if (oData.ot == ObstacleType.TEMP2)
            {
                Debug.Log("Obstacle]TEMP2");
            }
        }
    }
}
