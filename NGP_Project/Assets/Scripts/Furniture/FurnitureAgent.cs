using UnityEngine;

public class FurnitureAgent : ItemUseListener
{
    [Header("// Readonly")]
    [SerializeField] ItemSO _itemSO = null;

    public void SetItem(ItemSO _value)
    {
        _itemSO = _value;
    }

    public override void OnUse(Inventory _inventory, Item _itemValue)
    {
        base.OnUse(_inventory, _itemValue);
    }
}
