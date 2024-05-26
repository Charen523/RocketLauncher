using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class RocketController : MonoBehaviour
{
    private EnergySystem _energySystem;
    private RocketMovement _rocketMovement;

    private PlayerInput _playerInput;

    private bool _isMoving;
    private bool _isBoosting;
    private Vector2 _movementDirection = Vector2.zero;

    private void Awake()
    {
        _energySystem = GetComponent<EnergySystem>();
        _rocketMovement = GetComponent<RocketMovement>();

        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        StartCoroutine(DecreaseEnergy());
        _energySystem.NoFuel += OutOfFuel;
    }

    private void FixedUpdate()
    {
        _rocketMovement.ApplyMovement(_movementDirection);
        _rocketMovement.ApplyBoost(_isBoosting);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementDirection = context.ReadValue<Vector2>().normalized;
        _isMoving = _movementDirection != Vector2.zero;
    }

    public void OnBoost(InputAction.CallbackContext context)
    {
        _isBoosting = (context.phase == InputActionPhase.Performed);
    }

    private void OutOfFuel()
    {
        _playerInput.enabled = false; //연료 없음.

    }

    IEnumerator DecreaseEnergy()
    {
        while (true) {
            if (_isMoving)
            {
                bool energyLeft = _isBoosting ? _energySystem.UseEnergy(3) : _energySystem.UseEnergy(1);
                if (!energyLeft)
                {
                    break;
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }
}