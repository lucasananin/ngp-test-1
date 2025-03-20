using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public class Inventory
{
    [SerializeField] List<Item> _items = null;

    public bool TryAdd(ItemSO _soValue, int _quantityValue)
    {
        if (HasItem(_soValue, out Item _itemGrabbed))
        {
            _itemGrabbed.Quantity += _quantityValue;
            // se passar da quantidade maxima, cria uma nova instancia.
        }
        else
        {
            var _newItemInstance = new Item()
            {
                SO = _soValue,
                Quantity = _quantityValue,
            };
            _items.Add(_newItemInstance);
        }

        return false;
    }

    public bool HasItem(ItemSO _soValue/*, int _quantityValue*/, out Item _itemToReturn)
    {
        int _count = _items.Count;

        for (int i = 0; i < _count; i++)
        {
            var _item = _items[i];

            if (_item.SO.name == _soValue.name /*&& !_item.HasMaxQuantity()*/)
            {
                _itemToReturn = _item;
                return true;
            }
        }

        _itemToReturn = null;
        return false;
    }
}
