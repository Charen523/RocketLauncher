using UnityEngine;
using UnityEngine.InputSystem;

public class RocketController : MonoBehaviour
{
    private EnergySystem _energySystem;
    private RocketMovement _rocketMovement;
    
    private bool _isBoosting;
    private Vector2 _movementDirection = Vector2.zero;
    
    private void Awake()
    {
        _energySystem = GetComponent<EnergySystem>();
        _rocketMovement = GetComponent<RocketMovement>();
    }


    private void FixedUpdate()
    {
        _rocketMovement.ApplyMovement(_movementDirection);
        _rocketMovement.ApplyBoost(_isBoosting);
    }

    // TODO : OnMove 구현
    public void OnMove(InputAction.CallbackContext context)
    {
        _movementDirection = context.ReadValue<Vector2>().normalized;
    }

    // TODO : OnBoost 구현
    // private void OnBoost...
    public void OnBoost(InputAction.CallbackContext context)
    {
        _isBoosting = (context.phase == InputActionPhase.Performed);
    }
}