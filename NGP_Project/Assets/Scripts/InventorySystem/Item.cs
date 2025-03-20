using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField] ItemSO _so = null;
    [SerializeField] int _amount = 0;

    public ItemSO SO { get => _so; set => _so = value; }
    public int Amount { get => _amount; set => _amount = value; }

    //public bool HasMaxQuantity()
    //{
    //    return _quantity >= _so.MaxQuantity;
    //}

    //public int IncreaseQuantity(int _value)
    //{
    //    _quantity += _value;

    //    if (_quantity > _so.MaxQuantity)
    //    {
    //        var _remainder = _quantity - _so.MaxQuantity;
    //        _quantity = _so.MaxQuantity;
    //        return _remainder;
    //    }
    //    else
    //    {
    //        return 0;
    //    }
    //}

    //public bool IsFull()
    //{
    //    return _quantity >= _so.MaxQuantity;
    //}
}
