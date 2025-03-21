using UnityEngine;
using UnityEngine.Events;

public class ItemUISlot : MonoBehaviour
{
    [SerializeField] InventorySO _inventorySO = null;
    [SerializeField] Item _item = null;

    public event UnityAction<Item> OnValueChanged = null;

    public InventorySO InventorySO { get => _inventorySO; }
    public Item Item { get => _item; }

    public void Init(InventorySO _inventoryValue, Item _itemValue)
    {
        _inventorySO = _inventoryValue;
        _item = _itemValue;
        OnValueChanged?.Invoke(_item);
    }

    public void Use()
    {
        _item.Use(_inventorySO.Inventory);
    }
}
