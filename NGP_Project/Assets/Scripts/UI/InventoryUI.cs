using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : CanvasView
{
    [SerializeField] InventorySO _inventory = null;
    [SerializeField] ItemUISlot _prefab = null;
    [SerializeField] Transform _content = null;

    [Header("// Readonly")]
    [SerializeField] List<ItemUISlot> _slots = null;

    private void Awake()
    {
        InstantHide();
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsVisible())
            {
                InstantHide();
            }
            else
            {
                InstantShow();
                UpdateVisuals();
            }
        }

        base.Update();
    }

    private void OnEnable()
    {
        _inventory.AddListener(UpdateVisuals);
        DropItemSlot.OnDrop_Action += SwapItems;
    }

    private void OnDisable()
    {
        _inventory.RemoveListener(UpdateVisuals);
        DropItemSlot.OnDrop_Action -= SwapItems;
    }

    public void UpdateVisuals()
    {
        if (!IsVisible()) return;

        ClearSlots();

        var _itemsList = _inventory.GetItemsList();
        var _count = _itemsList.Count;

        for (int i = 0; i < _count; i++)
        {
            var _newSlot = Instantiate(_prefab, _content);
            _newSlot.Init(_inventory, _itemsList[i]);
            _slots.Add(_newSlot);
        }
    }

    private void ClearSlots()
    {
        int _count = _slots.Count;

        for (int i = _count - 1; i >= 0; i--)
        {
            Destroy(_slots[i].gameObject);
        }

        _slots.Clear();
    }

    private void SwapItems(ItemUISlot _slot1, ItemUISlot _slot2)
    {
        _inventory.SwapItems(_slot1.Item, _slot2.Item);
        UpdateVisuals();
    }
}
