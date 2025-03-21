using UnityEngine;
using UnityEngine.UI;

public class LoadButtonEnabler : MonoBehaviour
{
    [SerializeField] Button _button = null;

    private void LateUpdate()
    {
        _button.interactable = PersistenceHandler.HasAnySaveFile();
    }
}
