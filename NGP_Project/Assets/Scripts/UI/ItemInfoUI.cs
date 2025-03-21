using TMPro;
using UnityEngine;

public class ItemInfoUI : CanvasView
{
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

    private void InstantShow(ItemUISlot arg0)
    {
        InstantShow();
    }

    private void InstantHide(ItemUISlot arg0)
    {
        InstantHide();
    }
}
