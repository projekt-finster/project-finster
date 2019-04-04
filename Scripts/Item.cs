//by: tabulator

using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class Item : ScriptableObject
{  
    [Tooltip("Typy przedmiotów:\n 0 - broń\n 1 - pancerz\n 2 - magia\n 3 - alchemia\n 4 - inne")]
    public int itemType;
    public int itemID;
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
}
