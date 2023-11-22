using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Store/Items" ,fileName = "new store item")]
public class StoreItemSO : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public int itemPrice;
    public Sprite itemSprite;

 
}
