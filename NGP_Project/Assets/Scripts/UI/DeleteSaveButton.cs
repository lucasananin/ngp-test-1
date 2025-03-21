using UnityEngine;
using UnityEngine.UI;

public class DeleteSaveButton : MonoBehaviour
{
    [SerializeField] Button _button = null;

    private void OnValidate()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(DeleteSaveFiles);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(DeleteSaveFiles);
    }

    public void DeleteSaveFiles()
    {
        PersistenceHandler.DeleteAllSaves();
    }
}
