using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DropEmpty : MonoBehaviour, IDropHandler
{
    public static event UnityAction OnDrop = null;

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        OnDrop?.Invoke();
    }
}
