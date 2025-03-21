using UnityEngine;
using UnityEngine.UI;

public class ItemUIIcon : ItemUIDependant
{
    [SerializeField] Image _image = null;

    private void OnEnable()
    {
        _slot.OnValueChanged += UpdateVisuals;
    }

    private void OnDisable()
    {
        _slot.OnValueChanged -= UpdateVisuals;
    }

    private void UpdateVisuals(Item _item)
    {
        _image.sprite = _item.SO.Icon;
    }
}
