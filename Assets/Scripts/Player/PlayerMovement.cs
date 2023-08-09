using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private const float _speed = 5f;
    [SerializeField] private const float _accelerationSpeed = 7.5f;
    [SerializeField] private const float _sneakingSpeed = 3f;


    private Animator _animator;
    private Rigidbody2D _rb;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    internal Vector2 lastMotionVector;
    

    private float MovementSpeed(float speed = _speed, float accelerattionSpeed = _accelerationSpeed, float sneakingSpeed = _sneakingSpeed)
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            return accelerattionSpeed;
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            return sneakingSpeed;
        else return speed;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _animator.SetFloat("Horizontal", _smoothedMovementInput.x);
        _animator.SetFloat("Vertical", _smoothedMovementInput.y);
        _animator.SetFloat("Speed", _smoothedMovementInput.sqrMagnitude);

        if (_movementInput.x != 0 || _movementInput.y != 0) 
        {
            lastMotionVector = new Vector2(
                _smoothedMovementInput.x,
                _smoothedMovementInput.y
                ).normalized;

            _animator.SetFloat("LastHorizontal", _smoothedMovementInput.x);
            _animator.SetFloat("LastVertical", _smoothedMovementInput.y);
        }
    }
    private void FixedUpdate()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f);
        _rb.velocity = _smoothedMovementInput * MovementSpeed();
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}


