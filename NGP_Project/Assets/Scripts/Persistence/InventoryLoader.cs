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
        var _loadedInventory = PersistenceHandler.Load<ItemListDAO>(Inventory.INVENTORY_KEY);

        //foreach (var item in _loadedInventory.itemDAOs)
        //{
        //    Debug.Log($"{item.so_id} - {item.amount}");
        //}

        _emptyInventory.Clear();
        int _count = _loadedInventory.itemDAOs.Count;

        for (int i = 0; i < _loadedInventory.itemDAOs.Count; i++)
        {
            var _daoList = _loadedInventory.itemDAOs[i];
            var _so = GetItemSO(_daoList.so_id);
            _emptyInventory.TryAdd(_so, _daoList.amount);
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        _inventory.Save();
    }

    [ContextMenu("DeleteAllSaves()")]
    public void DeleteFiles()
    {
        PersistenceHandler.DeleteAllSaves();
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
