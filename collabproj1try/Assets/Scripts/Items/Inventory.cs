using UnityEngine;


[CreateAssetMenu(fileName = "inventory", menuName = "item/inventory")]
public class Inventory : ScriptableObject
{
    public ItemBase wood;

    public ItemBase iron;

    public ItemBase gold;

    public ItemBase gunPowder;
}
