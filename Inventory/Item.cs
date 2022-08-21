using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IPlayerUsable
{
    public ItemScriptableObject item;
    public int amount;
    public void OnUsable(GameObject ply)
    {
        ply.GetComponent<Inventory>().AddItem(this.item, this.amount);
        Destroy(gameObject);
    }
}
