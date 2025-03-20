using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    [SerializeField] InventorySO _inventorySO = null;
    [SerializeField] ItemSO[] _itemSOs = null;
    [SerializeField] int _quantity = 1;

    [ContextMenu("AddItem()")]
    public void AddItem()
    {
        var _randomIndex = Random.Range(0, _itemSOs.Length);
        //var _randomQuantity = Random.Range(1, 10);
        var _so = _itemSOs[_randomIndex];
        _inventorySO.TryAdd(_so, _quantity);
    }
}
