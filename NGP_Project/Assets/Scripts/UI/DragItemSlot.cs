using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragItemSlot : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] RectTransform _rect = null;
    [SerializeField] ItemUISlot _itemSlot = null;

    public static event UnityAction<ItemUISlot, Vector2> OnBeginDrag_Action = null;
    public static event UnityAction<DragItemSlot, PointerEventData> OnDrag_Action = null;

    private void OnValidate()
    {
        _rect = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDrag_Action?.Invoke(_itemSlot, _rect.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDrag_Action?.Invoke(this, eventData);
    }
}
