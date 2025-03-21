using UnityEngine;

public class ItemUseListener : MonoBehaviour
{
    [SerializeField] ItemUseSO _so = null;

    private void OnEnable()
    {
        _so.AddListener(PrintMessage);
    }

    private void OnDisable()
    {
        _so.RemoveListener(PrintMessage);
    }

    private void PrintMessage(Inventory _inventory, Item _itemValue)
    {
        _itemValue.DecreaseAmount(_inventory);
        Debug.Log($"// {_itemValue.SO.DisplayName} used!");
    }
}
