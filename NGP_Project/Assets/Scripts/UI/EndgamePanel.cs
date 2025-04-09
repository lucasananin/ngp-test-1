using System.Collections;
using UnityEngine;

public class EndgamePanel : CanvasView
{
    [SerializeField] FurnitureBehaviour[] _furnitures = null;
    [SerializeField] float _time = 3f;
    [SerializeField] bool _hasShow = false;

    private void Awake()
    {
        InstantHide();
    }

    protected override void Update()
    {
        if (AllFurnituresSet() && !_hasShow)
        {
            _hasShow = true;
            Show();
            StartCoroutine(Show_Routine());
        }

        base.Update();
    }

    private bool AllFurnituresSet()
    {
        int _count = _furnitures.Length;
        int _value = 0;

        for (int i = 0; i < _count; i++)
        {
            _value += _furnitures[i].IsSet ? 1 : 0;
        }

        return _value >= _furnitures.Length;
    }

    private IEnumerator Show_Routine()
    {
        yield return new WaitForSeconds(_time);
        Hide();
    }
}
