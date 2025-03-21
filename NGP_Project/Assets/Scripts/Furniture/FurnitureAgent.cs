using UnityEngine;

public class FurnitureAgent : ItemUseListener
{
    [Header("// Readonly")]
    [SerializeField] FurnitureBehaviour _furniture = null;
    [SerializeField] ItemSO _itemSO = null;

    public void SetItem(FurnitureBehaviour _furniture, ItemSO _value)
    {
        _itemSO = _value;
        this._furniture = _furniture;
    }

    public override void OnUse(Inventory _inventory, Item _itemValue)
    {
        base.OnUse(_inventory, _itemValue);

        if (_itemValue.SO.name == _itemSO.name)
        {
            _furniture.SetValue(true);
            _inventory.RemoveItem(_itemValue);
            FindFirstObjectByType<InventoryUI>().gameObject.SetActive(false);
            Debug.Log($"Correct Item");
        }
        else
        {
            Debug.Log($"Incorrect Item");
        }
    }
}
