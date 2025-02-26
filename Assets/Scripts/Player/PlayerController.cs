using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    public float walkSpeed;
    public float runSpeed;
    Vector2 moveInput;

    public float CurrentMoveSpeed{get
    {
        if(IsMoving)
        {
            if(IsRunning)
            {
                return runSpeed;
            }
            else
            {
                return walkSpeed;
            }
        }
        else
        {
            return 0;
        }
    }
    }

    [SerializeField]
    private bool _isMoving = false;


    public bool IsMoving { get
    {
        return _isMoving;
    } 
    private set
    {
        _isMoving = value;
        animator.SetBool("isMoving",value);
    }
    }
    
    [SerializeField]
    private bool _isrunning = false;
    public bool IsRunning
    {
        get
        {
            return _isrunning;
        }
        set
        {
            animator.SetBool("isRunning", value);
        }
    }

    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
    
    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 MoveInput)
    {
        if(moveInput.x > 0)
        {

        }
        if(moveInput.x < 0)
        {

        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            IsRunning = true;
        }
        else if (context.canceled)
        {
            IsRunning = false;
        }
    }
   
}
