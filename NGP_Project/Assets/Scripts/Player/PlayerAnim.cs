using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb = null;
    [SerializeField] Animator _animator = null;

    private int IS_WALKING_HASH = Animator.StringToHash("IsWalking");

    private void LateUpdate()
    {
        _animator.SetBool(IS_WALKING_HASH, _rb.linearVelocity != Vector2.zero);

        if (_rb.linearVelocity.x > 0)
        {
            Flip(true);
        }   
        else if (_rb.linearVelocity.x < 0)
        {
            Flip(false);
        }
    }

    public void Flip(bool _toTheRight)
    {
        transform.localScale = new Vector3(_toTheRight ? 1 : -1, 1, 1);
    }
}
