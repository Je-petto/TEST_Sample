using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {NONE, COIN, HP, }

[CreateAssetMenu(menuName = "ScriptableObject/ItemData", fileName = "ItemData")]
public class ItemData : ScriptableObject
{
    public ItemType it;
   
   

    public int pulsScore = 10;

    public float plusHP = 10f;



}
