using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    [SerializeField] Sprite _icon = null;
    [SerializeField] string _displayName = null;
    [SerializeField] int _maxQuantity = 10;

    public Sprite Icon { get => _icon; set => _icon = value; }
    public string DisplayName { get => _displayName; set => _displayName = value; }
    public int MaxQuantity { get => _maxQuantity; set => _maxQuantity = value; }
}
