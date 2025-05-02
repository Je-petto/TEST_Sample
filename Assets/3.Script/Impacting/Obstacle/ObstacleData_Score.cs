using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObstacleData_Score", fileName = "ObstacleData_Score")]
public class ObstacleData_Score : ObstacleData
{
    public int minusScore = -10; //스코어의 점수를 깎음
}
