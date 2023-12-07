using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Store/Items" ,fileName = "new store item")]
public class StoreItemSO : ScriptableObject
{
    public int itemPrice;
    public int itemBoost;
    public Sprite itemSprite;
    public AbilitiesSO abilityRef;

    public void OnClick()
    {
        abilityRef.abilityMastery += itemBoost;
    }
}
