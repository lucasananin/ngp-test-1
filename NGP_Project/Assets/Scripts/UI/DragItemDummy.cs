using UnityEngine;
using UnityEngine.EventSystems;

public class DragItemDummy : MonoBehaviour/*, IDragHandler*/
{
    [SerializeField] Canvas _canvas = null;
    [SerializeField] RectTransform _rect = null;
    [SerializeField] DragItemSlot _item = null;

    public static ItemUISlot ItemBeingDragged = null;

    private void Awake()
    {
        _canvas = GetComponentInParent<Canvas>();
    }

    private void OnValidate()
    {
        _rect = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        DragItemSlot.OnBeginDrag_UnityAction += Begin;
        DragItemSlot.OnDrag_UnityAction += Drag;
        DragItemSlot.OnEndDrag_UnityAction += EndDrag;
    }

    private void OnDisable()
    {
        DragItemSlot.OnBeginDrag_UnityAction -= Begin;
        DragItemSlot.OnDrag_UnityAction -= Drag;
        DragItemSlot.OnEndDrag_UnityAction -= EndDrag;
    }

    private void Begin(ItemUISlot arg0, Vector2 _initialPosition)
    {
        //_item = arg0;
        ItemBeingDragged = arg0;
        _rect.position = _initialPosition;
        //_rect.anchoredPosition = arg0.GetComponent<RectTransform>().anchoredPosition;
    }

    private void Drag(DragItemSlot arg0, PointerEventData eventData)
    {
        _rect.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    private void EndDrag(DragItemSlot arg0)
    {
        _rect.position = Vector2.one * 123456f;
    }

    //public void OnDrag(PointerEventData eventData)
    //{
    //    _rect.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    //}
}
