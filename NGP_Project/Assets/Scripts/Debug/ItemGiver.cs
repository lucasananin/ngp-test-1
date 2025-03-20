using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    [SerializeField] InventorySO _inventorySO = null;
    [SerializeField] ItemSO[] _itemSOs = null;
    [SerializeField] Vector2 _amountRange = Vector2.one;

    [ContextMenu("AddItem()")]
    public void AddItem()
    {
        var _randomIndex = Random.Range(0, _itemSOs.Length);
        var _amount = (int)Random.Range(_amountRange.x, _amountRange.y);
        var _so = _itemSOs[_randomIndex];
        _inventorySO.TryAdd(_so, _amount);
    }
}
