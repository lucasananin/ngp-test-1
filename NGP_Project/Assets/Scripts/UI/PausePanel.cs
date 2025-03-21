using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PausePanel : CanvasView
{
    [SerializeField] SceneLoader _sceneLoader = null;
    [SerializeField] Button _saveAndReturnButton = null;

    public static event UnityAction OnSaveAndReturn = null;

    private void Awake()
    {
        InstantHide();
    }

    private void OnEnable()
    {
        _saveAndReturnButton.onClick.AddListener(SaveAndReturn);
    }

    private void OnDisable()
    {
        _saveAndReturnButton.onClick.RemoveListener(SaveAndReturn);
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsVisible())
            {
                Time.timeScale = 1;
                InstantHide();
            }
            else
            {
                Time.timeScale = 0;
                InstantShow();
            }
        }

        base.Update();
    }

    private void SaveAndReturn()
    {
        Time.timeScale = 1;
        OnSaveAndReturn?.Invoke();
        _sceneLoader.Load();
    }
}
