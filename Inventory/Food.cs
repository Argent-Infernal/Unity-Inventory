using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food Item", menuName = "Inventory/Items/Food")]
public class Food : ItemScriptableObject
{
    private void Start()
    {
        itemType = ItemType.Food;
    }
}
