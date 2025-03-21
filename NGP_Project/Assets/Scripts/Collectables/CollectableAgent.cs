using UnityEngine;

public class CollectableAgent : MonoBehaviour
{
    [SerializeField] InventorySO _inventory = null;

    public InventorySO Inventory { get => _inventory; }
}
