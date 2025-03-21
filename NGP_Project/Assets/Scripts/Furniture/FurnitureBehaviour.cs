using UnityEngine;

public class FurnitureBehaviour : MonoBehaviour
{
    [SerializeField] ItemSO _requiredItem = null;
    [SerializeField] Collider2D _trigger = null;
    [SerializeField] SpriteRenderer _areaRenderer = null;
    [SerializeField] SpriteRenderer _iconRenderer = null;

    [Header("// Readonly")]
    [SerializeField] bool _isSet = false;

    public bool IsSet { get => _isSet; }

    //private void Start()
    //{
    //    SetValue(_isSet);
    //}

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.TryGetComponent(out FurnitureAgent _agent))
        {
            _areaRenderer.color = Color.green;
            _agent.SetItem(this, _requiredItem);
        }
    }

    private void OnTriggerExit2D(Collider2D _other)
    {
        if (_other.TryGetComponent(out FurnitureAgent _agent))
        {
            _areaRenderer.color = Color.red;
            _agent.SetItem(null, null);
        }
    }

    public void SetValue(bool _value)
    {
        _isSet = _value;
        UpdateVisuals();
    }

    public void UpdateVisuals()
    {
        _trigger.enabled = !_isSet;
        _areaRenderer.enabled = !_isSet;
        _areaRenderer.color = Color.red;
        _iconRenderer.enabled = _isSet;
        _iconRenderer.sprite = _requiredItem.Icon;
    }
}
