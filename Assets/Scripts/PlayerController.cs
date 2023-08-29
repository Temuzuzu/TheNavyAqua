using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 2f;
    [SerializeField] Rigidbody2D rb;
    private Vector2 _movementDirection;
    private Vector2 _movementPos;

    [Header("Dash setting")]
    private bool _canDash = true;
    private bool _isDashing;
    [SerializeField] private float _dashingPower = 25f;
    [SerializeField] float dashingTime = 1f;
    [SerializeField] private float _dashingCooldown = 1f;

    void Start()
    {
        _canDash = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_isDashing)
        {
            return;
        }
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash)
        {
            StartCoroutine(Dash());

        }
        _movementDirection = new Vector2(moveX,moveY).normalized;
    }

    void FixedUpdate()
    {
        if (_isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(_movementDirection.x * _movementSpeed, _movementDirection.y * _movementSpeed);
    }
    
    private IEnumerator Dash()
    {
        _canDash = false;
        _isDashing = true;
        rb.velocity = new Vector2(_movementDirection.x * _dashingPower, _movementDirection.y * _dashingPower);
        yield return new WaitForSeconds(dashingTime);
        _isDashing = false; 

        yield return new WaitForSeconds(_dashingCooldown);
        _canDash = true;
    }

}
