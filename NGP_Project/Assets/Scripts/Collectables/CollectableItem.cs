using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] ItemSO _itemSO = null;
    [SerializeField] int _amount = 1;

    public void Init(ItemSO _so, int _amountValue)
    {
        _itemSO = _so;
        _amount = _amountValue;
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.TryGetComponent(out CollectableAgent _agent))
        {
            _agent.Inventory.TryAdd(_itemSO, _amount);
            Destroy(gameObject);
        }
    }
}
