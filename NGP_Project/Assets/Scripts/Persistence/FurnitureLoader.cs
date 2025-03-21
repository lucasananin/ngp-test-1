using UnityEngine;

public class FurnitureLoader : AbstractDAOLoader
{
    [SerializeField] string _key = null;
    [SerializeField] FurnitureBehaviour _behaviour = null;

    private void Start()
    {
        Load();
    }

    public override void Load()
    {
        var _loadedDao = PersistenceHandler.Load<FurnitureDAO>(GenerateKey());

        if (_loadedDao == null)
        {
            _behaviour.SetValue(false);
        }
        else
        {
            _behaviour.SetValue(_loadedDao.isSet);
        }
    }

    public override void Save()
    {
        var _dao = new FurnitureDAO() { isSet = _behaviour.IsSet };
        PersistenceHandler.Save(_dao, GenerateKey());
    }

    public override string GenerateKey()
    {
        return $"Furniture_{_key}";
    }
}

[System.Serializable]
public class FurnitureDAO
{
    public bool isSet = false;
}