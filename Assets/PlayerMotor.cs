using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rigidbody2D;
    public float speed = 4;
    public float jumpForce = 5;
    public float maxJump = 10;
    public float maxSpeed = 6;
    public float stoppingForce = 10;
    public float dashForce = 6;
    private float initScale;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private bool canJump = true;
    private bool canDoubleJump = true;
    private bool canDash = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnDash()
    {
        //Debug.Log("Dashing");
        if (canDash)
        {
            rigidbody2D.AddForce(new Vector2(direction.x * dashForce,0), ForceMode2D.Impulse);
            canDash = false;
            StartCoroutine(ResetDash(1));
        }
    }

    IEnumerator ResetDash(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        canDash = true;
    }
    private void Start()
    {
       rigidbody2D = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        HandlePlayerMovement();

        rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //++;
        //if (currentJump >= maxJump)
        {
            canJump = false;
        }

        MaxSpeedLimiting();
        //transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * speed;
    }

    private void HandlePlayerMovement()
    {
        if (direction.x != 0)
        {
            rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));
            _animator .SetBool("IsMoving", true);
        }
        else if (rigidbody2D.linearVelocityX != 0)
        {
            //Zatrzymywanie
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));
        }
        if (direction.x == 0)
        {
            _animator.SetBool("IsMoving", false);

        }
    }

    private void MaxSpeedLimiting()
    {
        if(!canDash)
        {
            return;
        }

        if (rigidbody2D.linearVelocityX >= maxSpeed)
        {
            rigidbody2D.linearVelocityX = maxSpeed;
        }
        else if (rigidbody2D.linearVelocityX <= -maxSpeed)
        {
            rigidbody2D.linearVelocityX = -maxSpeed;
        }
    }

    private void OnMove(InputValue value)
    {
        //Debug.Log("Move");
        //Debug.Log(value.Get<Vector2>());
        direction = value.Get<Vector2>();
       
    }
    private void OnJump()
    {
        if (canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
        else if (canDoubleJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canDoubleJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    canDoubleJump = true;
        _animator.SetBool("canJump", false);
    }
}
   