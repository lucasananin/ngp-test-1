using UnityEngine;

public class EquippableListener : ItemUseListener
{
    [SerializeField] SpriteRenderer _renderer = null;

    [Header("// Readonly")]
    [SerializeField] Inventory _currentInventory = null;
    [SerializeField] Item _currentItem = null;

    public Item CurrentItem { get => _currentItem; }

    public override void OnUse(Inventory _inventoryValue, Item _itemValue)
    {
        base.OnUse(_inventoryValue, _itemValue);

        _inventoryValue.RemoveItem(_itemValue);
        _currentInventory?.Add(_currentItem);

        _currentInventory = _inventoryValue;
        _currentItem = _itemValue;

        UpdateVisuals();
        FindFirstObjectByType<InventoryUI>().InstantHide();
    }

    public void UpdateVisuals()
    {
        _renderer.sprite = _currentItem == null ? null : _currentItem.SO.Icon;
    }

    public void SetItem(Item _value)
    {
        _currentItem = _value;
        UpdateVisuals();
    }
}
