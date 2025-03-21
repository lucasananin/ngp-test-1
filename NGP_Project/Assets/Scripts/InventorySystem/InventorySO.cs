using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InventorySO", menuName = "Scriptable Objects/InventorySO")]
public class InventorySO : ScriptableObject
{
    [SerializeField] Inventory _inventory = null;

    public Inventory Inventory { get => _inventory; private set => _inventory = value; }

    public bool TryAdd(ItemSO _soValue, int _quantityValue)
    {
        return _inventory.TryAdd(_soValue, _quantityValue);
    }

    public List<Item> GetItemsList()
    {
        return _inventory.Items;
    }

    public void AddListener(UnityAction _action)
    {
        _inventory.OnChanged += _action;
    }

    public void RemoveListener(UnityAction _action)
    {
        _inventory.OnChanged -= _action;
    }

    public void SwapItems(Item _a, Item _b)
    {
        _inventory.SwapItems(_a, _b);
    }

    public void Clear()
    {
        _inventory.Clear();
    }

    public void Save()
    {
        _inventory.Save();
    }
}
