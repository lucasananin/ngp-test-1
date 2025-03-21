using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DropItemSlot : ItemUIDependant, IDropHandler
{
    public static event UnityAction<ItemUISlot, ItemUISlot> OnDrop_Action = null;

    public void OnDrop(PointerEventData eventData)
    {
        OnDrop_Action?.Invoke(DragItemDummy.ItemBeingDragged, _slot);
    }
}
