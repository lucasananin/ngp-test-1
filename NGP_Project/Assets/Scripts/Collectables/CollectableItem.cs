using UnityEngine;
using UnityEngine.Events;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] ItemSO _itemSO = null;
    [SerializeField] int _amount = 1;

    private event UnityAction<CollectableItem> OnCollected = null;

    public ItemSO ItemSO { get => _itemSO; }
    public int Amount { get => _amount; }

    public void Init(ItemSO _so, int _amountValue, UnityAction<CollectableItem> _onCollected)
    {
        _itemSO = _so;
        _amount = _amountValue;
        OnCollected = _onCollected;
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.TryGetComponent(out CollectableAgent _agent))
        {
            _agent.Inventory.TryAdd(_itemSO, _amount);
            OnCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
