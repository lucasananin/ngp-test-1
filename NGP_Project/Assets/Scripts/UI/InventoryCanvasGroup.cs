using UnityEngine;

public class InventoryCanvasGroup : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup = null;
    [SerializeField] float _alphaOnHidden = 0.5f;

    private void OnEnable()
    {
        DragItemSlot.OnBeginDrag_Action += Hide;
        DropItemSlot.OnDrop_Action += Show;
        DropEmpty.OnDrop += Show;
    }

    private void OnDisable()
    {
        DragItemSlot.OnBeginDrag_Action -= Hide;
        DropItemSlot.OnDrop_Action -= Show;
        DropEmpty.OnDrop -= Show;
    }

    private void Show(ItemUISlot arg0, ItemUISlot arg1)
    {
        Show();
    }

    private void Hide(ItemUISlot arg0, Vector2 arg1)
    {
        Hide();
    }

    private void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    private void Hide()
    {
        _canvasGroup.alpha = _alphaOnHidden;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = true;
    }
}
