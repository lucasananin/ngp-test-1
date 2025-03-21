using System;
using UnityEngine;

public class ItemUseListener : MonoBehaviour
{
    [SerializeField] ItemUseSO _so = null;

    private void OnEnable()
    {
        _so.AddListener(PrintMessage);
    }

    private void OnDisable()
    {
        _so.RemoveListener(PrintMessage);
    }

    private void PrintMessage(InventorySO arg0, Item arg1)
    {
        Debug.Log($"// {arg1.SO.DisplayName} used!");
    }
}
