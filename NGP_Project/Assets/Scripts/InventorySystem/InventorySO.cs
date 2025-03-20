using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "Scriptable Objects/InventorySO")]
public class InventorySO : ScriptableObject
{
    [SerializeField] Inventory _inventory = null;

    public bool TryAdd(ItemSO _soValue, int _quantityValue)
    {
        return _inventory.TryAdd(_soValue, _quantityValue);
    }
}
