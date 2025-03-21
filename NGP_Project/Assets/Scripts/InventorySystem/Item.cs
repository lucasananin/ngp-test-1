using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField] ItemSO _so = null;
    [SerializeField] int _amount = 0;

    public ItemSO SO { get => _so; set => _so = value; }
    public int Amount { get => _amount; set => _amount = value; }

    public void Use(Inventory _inventory)
    {
        _so.UseSO.Send(_inventory, this);
    }

    public void DecreaseAmount(Inventory _inventory)
    {
        _amount--;

        if (_amount <= 0)
        {
            _inventory.RemoveItem(this);
        }
    }
}
