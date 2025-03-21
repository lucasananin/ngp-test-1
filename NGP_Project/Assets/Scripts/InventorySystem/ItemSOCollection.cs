using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSOCollection", menuName = "Scriptable Objects/ItemSOCollection")]
public class ItemSOCollection : ScriptableObject
{
    [SerializeField] List<ItemSO> _list = null;

    public ItemSO GetByName(string _name)
    {
        int _count = _list.Count;

        for (int i = 0; i < _count; i++)
        {
            if (_list[i].name == _name)
            {
                return _list[i];
            }
        }

        return null;
    }
}
