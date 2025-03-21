using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoverItemSlot : ItemUIDependant, IPointerEnterHandler, IPointerExitHandler
{
    public static event UnityAction<ItemUISlot> OnEnter = null;
    public static event UnityAction<ItemUISlot> OnExit = null;

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnter?.Invoke(_slot);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnExit?.Invoke(_slot);
    }
}
