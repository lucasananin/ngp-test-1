using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "AudioSO", menuName = "Scriptable Objects/AudioSO")]
public class AudioSO : ScriptableObject
{
    [SerializeField] AudioClip _clip = null;
    [SerializeField] bool _isMusic = false;

    public static event UnityAction<AudioSO> OnPlayMusic = null;
    public static event UnityAction<AudioSO> OnPlaySfx = null;

    public AudioClip Clip { get => _clip; }
    public bool IsMusic { get => _isMusic; }

    public void Play()
    {
        if (_isMusic)
        {
            OnPlayMusic?.Invoke(this);
        }
        else
        {
            OnPlaySfx?.Invoke(this);
        }
    }
}
