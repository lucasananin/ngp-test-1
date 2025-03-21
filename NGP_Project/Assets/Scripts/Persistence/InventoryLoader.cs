using UnityEngine;

public class InventoryLoader : AbstractDAOLoader
{
    [SerializeField] InventorySO _inventory = null;
    [SerializeField] ItemSOCollection _itemSoCollection = null;

    private void Start()
    {
        Load();
    }

    [ContextMenu("Load()")]
    public override void Load()
    {
        var _loadedInventory = PersistenceHandler.Load<ItemListDAO>(GenerateKey());

        if (_loadedInventory == null || _loadedInventory.itemDAOs.Count <= 0)
        {
            return;
        }

        //foreach (var item in _loadedInventory.itemDAOs)
        //{
        //    Debug.Log($"{item.so_id} - {item.amount}");
        //}

        _inventory.Clear();
        int _count = _loadedInventory.itemDAOs.Count;

        for (int i = 0; i < _loadedInventory.itemDAOs.Count; i++)
        {
            var _daoList = _loadedInventory.itemDAOs[i];
            var _so = _itemSoCollection.GetItemSO(_daoList.so_id);
            _inventory.TryAdd(_so, _daoList.amount);
        }
    }

    [ContextMenu("Save()")]
    public override void Save()
    {
        _inventory.Save();
    }

    [ContextMenu("DeleteAllSaves()")]
    public void DeleteFiles()
    {
        PersistenceHandler.DeleteAllSaves();
    }

    public override string GenerateKey()
    {
        return Inventory.INVENTORY_KEY;
    }
}
