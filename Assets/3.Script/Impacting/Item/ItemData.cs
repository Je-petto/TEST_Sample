using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { NONE, COIN, HP, }

[CreateAssetMenu(menuName = "ScriptableObject/ItemData", fileName = "ItemData")]
public class ItemData : ScriptableObject
{
    public ItemType it;



    public int pulsScore = 10;

    public float plusHP = 10f;

    [Tooltip("움직일때의 회전값")] public float rotationSpeed = 50f; // 소환되어 회전하는 속도
    [Tooltip("스폰 확률 가중치 (높을수록 잘 나옴)")] public int spawnWeight = 1;

}
