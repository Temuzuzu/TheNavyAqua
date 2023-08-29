using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;

    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private float dashingPower = 25f;
    [SerializeField] float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;

    private Rigidbody2D rb;

    private Vector2 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = movementDirection * movementSpeed;
    }

    /*private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(transform.position.x * dashingPower, 0f);
        rb.velocity = new Vector2(transform.position.y * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    */
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        if(Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = new Vector2(-transform.localScale.y * dashingPower, 0f);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-transform.localScale.x * dashingPower, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(transform.localScale.y * dashingPower, 0f);
        }
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }



}
