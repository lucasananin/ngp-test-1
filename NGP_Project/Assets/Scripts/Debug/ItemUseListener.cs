using UnityEngine;

public class ItemUseListener : MonoBehaviour
{
    [SerializeField] protected ItemUseSO _useSO = null;

    private void OnEnable()
    {
        //_so.AddListener(PrintMessage);
        _useSO.AddListener(OnUse);
    }

    private void OnDisable()
    {
        //_so.RemoveListener(PrintMessage);
        _useSO.AddListener(OnUse);
    }

    private void PrintMessage(Inventory _inventory, Item _itemValue)
    {
        _itemValue.DecreaseAmount(_inventory);
        Debug.Log($"// {_itemValue.SO.DisplayName} used!");
    }

    public virtual void OnUse(Inventory _inventory, Item _itemValue)
    {
        //
    }
}
