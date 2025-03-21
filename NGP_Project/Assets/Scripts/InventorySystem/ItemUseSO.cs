using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ItemUseSO", menuName = "Scriptable Objects/ItemUseSO")]
public class ItemUseSO : ScriptableObject
{
    public event UnityAction<Inventory, Item> OnUsed = null;

    public void Send(Inventory _inventory, Item _item)
    {
        OnUsed?.Invoke(_inventory, _item);
    }

    public void AddListener(UnityAction<Inventory, Item> _action)
    {
        OnUsed += _action;
    }

    public void RemoveListener(UnityAction<Inventory, Item> _action)
    {
        OnUsed -= _action;
    }
}
