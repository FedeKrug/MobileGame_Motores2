using UnityEngine;

public class AbilitiesUI : MonoBehaviour
{
    [SerializeField] AbilityItemUI prefab;
    [SerializeField] AbilityItemSO[] items = new AbilityItemSO[0];
    [SerializeField] Transform parent = null;

    private void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            var newObj = Instantiate(prefab, parent);
            newObj.SetItem(items[i]);
        }
    }
}