using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObstacleData_Damage", fileName = "ObstacleData_Damage")]
public class ObstacleData_Damage : ObstacleData
{
    public float minusHP = -10f; // 캐릭터에게 줄 데미지

}
