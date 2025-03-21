using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ItemUseSO", menuName = "Scriptable Objects/ItemUseSO")]
public class ItemUseSO : ScriptableObject
{
    public event UnityAction<InventorySO, Item> OnUsed = null;

    public void Send(InventorySO _inventorySO, Item _item)
    {
        OnUsed?.Invoke(_inventorySO, _item);
    }

    public void AddListener(UnityAction<InventorySO, Item> _action)
    {
        OnUsed += _action;
    }

    public void RemoveListener(UnityAction<InventorySO, Item> _action)
    {
        OnUsed -= _action;
    }
}
