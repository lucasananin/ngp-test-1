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
        var _loadedDAO = PersistenceHandler.Load<ItemListDAO>(GenerateKey());

        _inventory.Clear();

        if (_loadedDAO == null || _loadedDAO.itemDAOs.Count <= 0)
        {
            return;
        }

        //foreach (var item in _loadedInventory.itemDAOs)
        //{
        //    Debug.Log($"{item.so_id} - {item.amount}");
        //}

        int _count = _loadedDAO.itemDAOs.Count;

        for (int i = 0; i < _count; i++)
        {
            var _daoList = _loadedDAO.itemDAOs[i];
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
