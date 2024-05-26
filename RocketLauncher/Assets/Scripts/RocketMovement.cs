using UnityEngine;
using UnityEngine.InputSystem;

public class RocketMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private bool _isBoosted;
    private readonly float SPEED = 5f;
    private readonly float ROTATIONSPEED = 0.1f;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    public void ApplyMovement(Vector2 direction)
    {
        // TODO : 회전을 적용하고 이동을 적용함
        Rotate(direction);
        Move(direction);
    }

    public void ApplyBoost(bool isPressed)
    {
        _isBoosted = isPressed;
    }

    private void Rotate(Vector2 direction)
    {
        // TODO : 완만한 회전을 적용함
        if (direction != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, ROTATIONSPEED);
        }else
        {
            float targetAngle = 0;
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, ROTATIONSPEED);
        }

       
    }

    private void Move(Vector2 direction)
    {
        // TODO : 움직임 적용
        //_isBoosted가 true면 속도 3배.
        if (direction != Vector2.zero)
        {
           _rb2d.velocity = direction * SPEED * (_isBoosted ? 3: 1);
        }
    }
}