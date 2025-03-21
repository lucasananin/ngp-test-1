using System.Collections;
using UnityEngine;

public class EquipmentLoader : AbstractDAOLoader
{
    [SerializeField] string _key = null;
    [SerializeField] EquippableListener _equip = null;
    [SerializeField] ItemSOCollection _itemSoCollection = null;

    private IEnumerator Start()
    {
        yield return null;
        Load();
    }

    public override void Load()
    {
        var _loadedDao = PersistenceHandler.Load<EquipmentDAO>(GenerateKey());

        if (_loadedDao == null)
        {
            _equip.SetItem(null);
        }
        else
        {
            var _newItem = new Item()
            {
                SO = _itemSoCollection.GetByName(_loadedDao.so_id),
                Amount = 1,
            };
            _equip.SetItem(_newItem);
        }
    }

    public override void Save()
    {
        if (_equip.CurrentItem != null)
        {
            var _newDao = new EquipmentDAO()
            {
                so_id = _equip.CurrentItem.SO.name,
            };
            PersistenceHandler.Save(_newDao, GenerateKey());
        }
    }

    public override string GenerateKey()
    {
        return $"Equipment_{_key}";
    }
}

public class EquipmentDAO
{
    public string so_id = null;
}