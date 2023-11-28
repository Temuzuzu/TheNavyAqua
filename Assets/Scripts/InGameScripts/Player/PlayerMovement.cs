using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rigidbody;

    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    private float moveX;
    private float moveY;

    private bool facingRight = true;

    public Animator animator;

    [Header("Dash setting")]
    private bool _canDash = true;
    private bool _isDashing;
    [SerializeField] private float _dashingPower = 25f;
    [SerializeField] float dashingTime = 1f;
    [SerializeField] private float _dashingCooldown = 1f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _canDash = true;
    }
    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (_isDashing)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash)
        {
            StartCoroutine(Dash());

        }
        _movementInput = new Vector2(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(moveX) > 0.1)
        {

            animator.SetBool("isSpeed", true);
        }
        else if (Mathf.Abs(moveY) > 0.1)
        {
            animator.SetBool("isSpeed", true);
        }
        else
        {
            animator.SetBool("isSpeed", false);
        }


        SetPlayerVelocity();
        RotateInDirectionOfInput();

        if (moveX > 0 && !facingRight)
        {
            Flip();
        }
        if (moveX < 0 && facingRight)
        {
            Flip();
        }

        if (_isDashing)
        {
            return;
        }
    }

    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
                    _smoothedMovementInput,
                    _movementInput,
                    ref _movementInputSmoothVelocity,
                    0.1f);

        _rigidbody.velocity = _smoothedMovementInput * _speed;
    }

    private void RotateInDirectionOfInput()
    {
        if (_movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    private IEnumerator Dash()
    {
        _canDash = false;
        _isDashing = true;
        _rigidbody.velocity = new Vector2(_movementInput.x * _dashingPower, _movementInput.y * _dashingPower);
        yield return new WaitForSeconds(dashingTime);
        _isDashing = false;
        yield return new WaitForSeconds(_dashingCooldown);
        _canDash = true;
    }
    
}

