using UnityEngine;
using UnityEngine.Events;

public class ItemUISlot : MonoBehaviour
{
    [SerializeField] Item _item = null;

    public event UnityAction<Item> OnValueChanged = null;

    public Item Item { get => _item; }

    public void Init(Item _value)
    {
        _item = _value;
        OnValueChanged?.Invoke(_item);
    }
}
