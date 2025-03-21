using TMPro;
using UnityEngine;

public class ItemUIAmount : ItemUIDependant
{
    [SerializeField] TextMeshProUGUI _text = null;

    private void OnEnable()
    {
        _slot.OnValueChanged += UpdateVisuals;
    }

    private void OnDisable()
    {
        _slot.OnValueChanged -= UpdateVisuals;
    }

    private void UpdateVisuals(Item _itemValue)
    {
        _text.text = _itemValue.Amount > 1 ? $"{_itemValue.Amount}" : string.Empty;
    }
}
