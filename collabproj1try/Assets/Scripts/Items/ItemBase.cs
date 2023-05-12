using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "Item", menuName = "item/item")]
public class ItemBase : ScriptableObject
{
    public string title;

    public Image img;

    public string description;
}
