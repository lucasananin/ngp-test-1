using System.Collections.Generic;
using UnityEngine;

public class ItemBoxLoader : AbstractDAOLoader
{
    [SerializeField] ItemBoxSpawner _spawner = null;
    [SerializeField] ItemSOCollection _itemSoCollection = null;

    private void Start()
    {
        Load();
    }

    public override void Load()
    {
        var _loadedDao = PersistenceHandler.Load<ItemBoxDAO>(GenerateKey());

        if (_loadedDao == null)
        {
            //
        }
        else
        {
            _spawner.SetIndex(_loadedDao.spawn_index);
            int _count = _loadedDao.boxes.Length;

            for (int i = 0; i < _count; i++)
            {
                var _box = _loadedDao.boxes[i];
                var _so = _itemSoCollection.GetByName(_box.so_id);
                _spawner.Spawn(_so, _box.amount);
            }
        }
    }

    public override void Save()
    {
        int _count = _spawner.SpawnedBoxes.Count;
        var _itemDaoList = new List<ItemDAO>();

        for (int i = 0; i < _count; i++)
        {
            var _box = _spawner.SpawnedBoxes[i];

            var _newItemDAO = new ItemDAO()
            {
                so_id = _box.ItemSO.name,
                amount = _box.Amount,
            };
            _itemDaoList.Add(_newItemDAO);
        }

        var _dao = new ItemBoxDAO()
        {
            boxes = _itemDaoList.ToArray(),
            spawn_index = _spawner.CurrentIndex,
        };
        PersistenceHandler.Save(_dao, GenerateKey());
    }

    public override string GenerateKey()
    {
        return $"box_spawner";
    }
}

[System.Serializable]
public class ItemBoxDAO
{
    public ItemDAO[] boxes = null;
    public int spawn_index = 0;
}