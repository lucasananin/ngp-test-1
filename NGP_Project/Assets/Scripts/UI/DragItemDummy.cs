using UnityEngine;
using UnityEngine.EventSystems;

public class DragItemDummy : MonoBehaviour/*, IDragHandler*//*, IDropHandler*/
{
    [SerializeField] Canvas _canvas = null;
    [SerializeField] RectTransform _rect = null;
    [SerializeField] ItemUISlot _myUiSlot = null;
    //[SerializeField] DragItemSlot _item = null;

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
        //DragItemSlot.OnEndDrag_UnityAction += EndDrag;
    }

    private void OnDisable()
    {
        DragItemSlot.OnBeginDrag_Action -= Begin;
        DragItemSlot.OnDrag_Action -= Drag;
        DropItemSlot.OnDrop_Action -= Disappear;
        //DragItemSlot.OnEndDrag_UnityAction -= EndDrag;
    }

    private void Begin(ItemUISlot slot, Vector2 _initialPosition)
    {
        //_item = arg0;
        ItemBeingDragged = slot;
        _rect.position = _initialPosition;
        _myUiSlot.Init(ItemBeingDragged.Item);
        //_rect.anchoredPosition = arg0.GetComponent<RectTransform>().anchoredPosition;
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

    //private void EndDrag(DragItemSlot arg0)
    //{
        
    //}

    //public void OnDrop(PointerEventData eventData)
    //{
    //    _rect.position = Vector2.one * 123456f;
    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    _rect.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    //}
}
