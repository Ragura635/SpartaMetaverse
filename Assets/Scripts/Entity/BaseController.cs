using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    
    [SerializeField] private SpriteRenderer characterRenderer;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection{get{return movementDirection;}}
    
    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection{get{return lookDirection;}}
    
    protected AnimationHandler animationHandler;
    protected StatHandler statHandler;
    
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    
    private bool isGrounded = false;
    public bool IsGrounded => isGrounded;
    
    protected void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();
        
        _rigidbody.freezeRotation = true;
    }

    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
        UpdateGrounded();
    }

    protected void FixedUpdate()
    {
        Movement(movementDirection);
    }
    
    protected virtual void HandleAction()
    {
        
    }
    
    private void Movement(Vector2 direction)
    {
        direction *= statHandler.Speed;
        float moveX = direction.x;
        float velocityY = _rigidbody.velocity.y;
        _rigidbody.velocity = new Vector2(moveX, velocityY);
        animationHandler.Move(direction);
    }
    
    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;
        
        characterRenderer.flipX = isLeft;
    }

    protected void UpdateGrounded()
    {
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        }
    }
    
    public void Jump()
    {
        if (!IsGrounded) return;
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, statHandler.JumpForce);
    }
}
