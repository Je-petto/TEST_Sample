using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType {NONE, TEMP1, TEMP2, }

[CreateAssetMenu(menuName = "ScriptableObject/ObstacleData", fileName = "ObstacleData")]
public class ObstacleData : ScriptableObject
{
    public ObstacleType ot;
   
   

    public int minusScore = -10;

    public float minusHP = 10f;



}
