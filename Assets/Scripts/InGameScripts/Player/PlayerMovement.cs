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
    private Vector2 _moveDirection;

    private float moveX;
    private float moveY;

    private bool facingRight = true;

    public Animator animator;

    [Header("Dash Setting")]
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldown = 1f;
    private bool isDashing;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        HealthManager.onPlayerDeath += DisablePlayerMovement;

    }
    private void OnDisable()
    {
        HealthManager.onPlayerDeath -= DisablePlayerMovement;

    }
    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (moveX > 0 && !facingRight)
        {
            Flip();
        }
        if (moveX < 0 && facingRight)
        {
            Flip();
        }
        _moveDirection = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

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
        isDashing = true;
        _rigidbody.velocity = new Vector2 (_moveDirection.x * dashSpeed, _moveDirection.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }

    private void DisablePlayerMovement()
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;
    }
    private void EnablePlayerMovement()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }
}

