using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField] ItemSO _so = null;
    [SerializeField] int _quantity = 0;

    public ItemSO SO { get => _so; set => _so = value; }
    public int Quantity { get => _quantity; set => _quantity = value; }

    public bool HasMaxQuantity()
    {
        return _quantity >= _so.MaxQuantity;
    }
}
