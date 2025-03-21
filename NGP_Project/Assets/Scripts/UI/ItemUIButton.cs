using UnityEngine;
using UnityEngine.UI;

public class ItemUIButton : ItemUIDependant
{
    [SerializeField] Button _button = null;

    private void OnEnable()
    {
        _button.onClick.AddListener(Use);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void Use()
    {
        _slot.Use();
    }
}
