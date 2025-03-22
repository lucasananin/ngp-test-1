using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb = null;
    [SerializeField] float _speed = 5f;
    [SerializeField] bool _isInverted = false;

    public bool IsInverted { get => _isInverted; set => _isInverted = value; }

    private void Update()
    {
        var _xInput = Input.GetAxisRaw("Horizontal");
        var _yInput = Input.GetAxisRaw("Vertical");
        var _direction = new Vector2(_xInput, _yInput).normalized;
        var _velocity = _direction * _speed;
        _rb.linearVelocity = _velocity * (_isInverted ? -1 : 1);
    }
}
