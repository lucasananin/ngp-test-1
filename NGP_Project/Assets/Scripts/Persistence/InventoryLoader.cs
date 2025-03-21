using System.Collections.Generic;
using UnityEngine;

public class InventoryLoader : MonoBehaviour
{
    [SerializeField] InventorySO _inventory = null;
    [SerializeField] InventorySO _emptyInventory = null;
    [SerializeField] List<ItemSO> _itemSoList = null;

    [ContextMenu("Load")]
    public void Load()
    {
        //_inventory.Clear();
        var _loadedInventory = PersistenceHandler.Load<ItemListDAO>(Inventory.INVENTORY_KEY);

        foreach (var item in _loadedInventory.itemDAOs)
        {
            Debug.Log($"{item.so_id} - {item.amount}");
        }

        _emptyInventory.Clear();
        foreach (var item in _loadedInventory.itemDAOs)
        {
            var _so = GetItemSO(item.so_id);
            _emptyInventory.TryAdd(_so, item.amount);
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        _inventory.Save();
    }

    public ItemSO GetItemSO(string _name)
    {
        int _count = _itemSoList.Count;

        for (int i = 0; i < _count; i++)
        {
            if (_itemSoList[i].name == _name)
            {
                return _itemSoList[i];
            }
        }

        return null;
    }
}
