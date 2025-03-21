using UnityEngine;

public class EquippableListener : ItemUseListener
{
    [SerializeField] SpriteRenderer _renderer = null;

    [Header("// Readonly")]
    [SerializeField] Inventory _currentInventory = null;
    [SerializeField] Item _currentItem = null;

    public override void OnUse(Inventory _inventoryValue, Item _itemValue)
    {
        base.OnUse(_inventoryValue, _itemValue);

        _inventoryValue.RemoveItem(_itemValue);
        _currentInventory?.Add(_currentItem);

        _currentInventory = _inventoryValue;
        _currentItem = _itemValue;

        _renderer.sprite = _currentItem.SO.Icon;
        FindFirstObjectByType<InventoryUI>().gameObject.SetActive(false);
    }
}
