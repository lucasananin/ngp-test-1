using TMPro;
using UnityEngine;

public class ItemDescriptionUI : CanvasView
{
    [SerializeField] TextMeshProUGUI _titleText = null;
    [SerializeField] TextMeshProUGUI _descriptionText = null;

    private void Awake()
    {
        InstantHide();
    }

    private void OnEnable()
    {
        HoverItemSlot.OnEnter += InstantShow;
        HoverItemSlot.OnExit += InstantHide;
    }

    private void OnDisable()
    {
        HoverItemSlot.OnEnter -= InstantShow;
        HoverItemSlot.OnExit -= InstantHide;
    }

    private void InstantShow(ItemUISlot _slotHovered)
    {
        Show();
        UpdateVisuals(_slotHovered);
    }

    private void InstantHide(ItemUISlot arg0)
    {
        Hide();
    }

    private void UpdateVisuals(ItemUISlot _slot)
    {
        _titleText.text = $"{_slot.Item.SO.DisplayName}";
        _descriptionText.text = $"{_slot.Item.SO.Description}";
    }
}
