using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField] ItemSO _so = null;
    [SerializeField] int _amount = 0;

    public ItemSO SO { get => _so; set => _so = value; }
    public int Amount { get => _amount; set => _amount = value; }
}
