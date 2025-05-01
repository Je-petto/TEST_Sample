using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public ItemData idata;

    void OnTriggerEnter(Collider col)
    {
                
        if(col.gameObject.tag == "Player")
        {
            
            if(idata.it == ItemType.COIN)
            {
                Debug.Log("ITEM]COIN");
            }
            if(idata.it == ItemType.HP)
            {
                Debug.Log("ITEM]HP");
            }
        }
    }
}
