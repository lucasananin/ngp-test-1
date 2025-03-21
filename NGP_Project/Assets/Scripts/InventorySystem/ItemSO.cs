using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    [SerializeField] Sprite _icon = null;
    [SerializeField] string _displayName = null;
    [SerializeField] int _maxAmount = 10;
    [SerializeField] ItemUseSO _useSO = null;
    [SerializeField, TextArea(10, 20)] string _description = null;

    public Sprite Icon { get => _icon; private set => _icon = value; }
    public string DisplayName { get => _displayName; private set => _displayName = value; }
    public int MaxAmount { get => _maxAmount; private set => _maxAmount = value; }
    public ItemUseSO UseSO { get => _useSO; private set => _useSO = value; }
    public string Description { get => _description; private set => _description = value; }

    private void OnValidate()
    {
        _displayName = name;
    }
}
