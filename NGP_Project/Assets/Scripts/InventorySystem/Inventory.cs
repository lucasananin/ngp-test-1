using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Inventory
{
    [SerializeField] List<Item> _items = null;

    public event UnityAction OnChanged = null;

    public List<Item> Items { get => _items; private set => _items = value; }

    public bool TryAdd(ItemSO _soValue, int _quantity)
    {
        while (_quantity > 0)
        {
            if (FindAvailableItem(_soValue, out Item _itemGrabbed))
            {
                int _spaceAvailable = _itemGrabbed.SO.MaxAmount - _itemGrabbed.Amount;
                int _amountToAdd = Mathf.Min(_spaceAvailable, _quantity);
                _itemGrabbed.Amount += _amountToAdd;
                _quantity -= _amountToAdd;
            }
            else
            {
                int _amountToAdd = Mathf.Min(_soValue.MaxAmount, _quantity);
                CreateAndAddNewItemInstance(_soValue, _amountToAdd);
                _quantity -= _amountToAdd;
            }
        }

        OnChanged?.Invoke();
        return false;
    }

    public bool FindAvailableItem(ItemSO _soValue, out Item _itemToReturn)
    {
        int _count = _items.Count;

        for (int i = 0; i < _count; i++)
        {
            var _item = _items[i];

            if (_item.SO.name == _soValue.name && _item.Amount < _soValue.MaxAmount)
            {
                _itemToReturn = _item;
                return true;
            }
        }

        _itemToReturn = null;
        return false;
    }

    private Item CreateAndAddNewItemInstance(ItemSO _soValue, int _quantityValue)
    {
        var _newItemInstance = new Item()
        {
            SO = _soValue,
            Amount = _quantityValue,
        };
        _items.Add(_newItemInstance);
        return _newItemInstance;
    }

    public void SwapItems(Item _a, Item _b)
    {
        var _indexA = _items.IndexOf(_a);
        var _indexB = _items.IndexOf(_b);

        var _tempItem = _items[_indexA];
        _items[_indexA] = _items[_indexB];
        _items[_indexB] = _tempItem;
    }

    public void RemoveItem(Item _itemValue)
    {
        _items.Remove(_itemValue);
        OnChanged?.Invoke();
    }
}
