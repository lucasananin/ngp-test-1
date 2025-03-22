using UnityEngine;

public class BeerBehaviour : ItemUseListener
{
    [SerializeField] PlayerMover _mover = null;
    [SerializeField] float _timeUntilSober = 5f;
    [SerializeField] float _timer = 0;
    [SerializeField] bool _isActive = false;

    private void Update()
    {
        if (!_isActive) return;

        _timer += Time.deltaTime;

        if (_timer > _timeUntilSober)
        {
            _timer = 0;
            _isActive = false;
            _mover.IsInverted = false;
        }
    }

    public void Init()
    {
        _timer = 0;
        _isActive = true;
        _mover.IsInverted = true;
    }

    public override void OnUse(Inventory _inventory, Item _itemValue)
    {
        base.OnUse(_inventory, _itemValue);

        _itemValue.DecreaseAmount(_inventory);
        Init();
        FindFirstObjectByType<InventoryUI>().InstantHide();
    }
}
