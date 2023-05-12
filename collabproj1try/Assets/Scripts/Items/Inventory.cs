using UnityEngine;


[CreateAssetMenu(fileName = "inventory", menuName = "item/inventory")]
public class Inventory : ScriptableObject
{
    public ItemBase[] items;
}
