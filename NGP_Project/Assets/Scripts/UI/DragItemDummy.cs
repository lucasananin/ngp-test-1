using UnityEngine;
using UnityEngine.EventSystems;

public class DragItemDummy : ItemUIDependant
{
    [SerializeField] Canvas _canvas = null;
    [SerializeField] RectTransform _rect = null;

    public static ItemUISlot ItemBeingDragged = null;

    private void Awake()
    {
        Disappear();
    }

    private void OnEnable()
    {
        DragItemSlot.OnBeginDrag_Action += Begin;
        DragItemSlot.OnDrag_Action += Drag;
        DropItemSlot.OnDrop_Action += Disappear;
        DropEmpty.OnDrop += Disappear;
    }

    private void OnDisable()
    {
        DragItemSlot.OnBeginDrag_Action -= Begin;
        DragItemSlot.OnDrag_Action -= Drag;
        DropItemSlot.OnDrop_Action -= Disappear;
        DropEmpty.OnDrop -= Disappear;
    }

    private void Begin(ItemUISlot _slotValue, Vector2 _initialPosition)
    {
        ItemBeingDragged = _slotValue;
        _rect.position = _initialPosition;
        _slot.Init(_slotValue.InventorySO, ItemBeingDragged.Item);
    }

    private void Drag(DragItemSlot arg0, PointerEventData eventData)
    {
        _rect.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    private void Disappear(ItemUISlot arg0, ItemUISlot arg1)
    {
        Disappear();
    }

    private void Disappear()
    {
        _rect.position = Vector2.one * 123456f;
    }
}
