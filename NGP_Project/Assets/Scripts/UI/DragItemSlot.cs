using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragItemSlot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] Canvas _canvas = null;
    [SerializeField] RectTransform _rect = null;
    [SerializeField] ItemUISlot _itemSlot = null;

    private Vector2 _defaultPosition = default;

    public static event UnityAction<ItemUISlot, Vector2> OnBeginDrag_UnityAction = null;
    public static event UnityAction<DragItemSlot, PointerEventData> OnDrag_UnityAction = null;
    public static event UnityAction<DragItemSlot> OnEndDrag_UnityAction = null;

    private void Awake()
    {
        _canvas = GetComponentInParent<Canvas>();
    }

    private void OnValidate()
    {
        _rect = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _defaultPosition = _rect.anchoredPosition;
        OnBeginDrag_UnityAction?.Invoke(_itemSlot, _rect.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //_rect.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        OnDrag_UnityAction?.Invoke(this, eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _rect.anchoredPosition = _defaultPosition;
        OnEndDrag_UnityAction?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
    }
}
