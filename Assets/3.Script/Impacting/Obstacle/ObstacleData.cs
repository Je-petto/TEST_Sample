using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType {NONE, TEMP1, TEMP2, }

[CreateAssetMenu(menuName = "ScriptableObject/ObstacleData", fileName = "ObstacleData")]
public class ObstacleData : ScriptableObject
{
    public ObstacleType ot;
   
   

    public int minusScore = -10; //스코어의 점수를 깎음

    public float minusHP = -10f; // 캐릭터에게 줄 데미지

    [Tooltip("움직일때의 회전값")]public float rotationSpeed = 50f; // 소환되어 회전하는 속도
    [Tooltip("스폰 확률 가중치 (높을수록 잘 나옴)")] public int spawnWeight = 1;





}
