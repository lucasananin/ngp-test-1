using UnityEngine;

public abstract class AbstractDAOLoader : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        PausePanel.OnSaveAndReturn += Save;
    }

    protected virtual void OnDisable()
    {
        PausePanel.OnSaveAndReturn -= Save;
    }

    public abstract void Save();
    public abstract void Load();
    public abstract string GenerateKey();
}
