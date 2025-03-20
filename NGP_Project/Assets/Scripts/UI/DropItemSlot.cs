using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DropItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] ItemUISlot _itemSlot = null;

    public static event UnityAction<ItemUISlot, ItemUISlot> OnDrop_Action = null;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log($"OnDrop", this);
        Debug.Log($"Item_1", DragItemDummy.ItemBeingDragged);
        Debug.Log($"Item_2", _itemSlot);
        OnDrop_Action?.Invoke(DragItemDummy.ItemBeingDragged, _itemSlot);
    }
}
