using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    private float deathCooldown = 0f;
    private bool isFlap = false;

    public bool godMode = false;
    
    PlaneGameManager planeGameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        planeGameManager = PlaneGameManager.Instance;
        
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        
        if(_animator == null)
            Debug.LogError(("Not Founded Animator"));
        
        if(_rigidbody == null)
            Debug.LogError(("Not Founded Rigidbody"));
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    planeGameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        
        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;
        
        if(isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }
        
        _rigidbody.velocity = velocity;
        
        float angle = Mathf.Clamp(_rigidbody.velocity.y * 10f, -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (godMode) return;
        
        if(isDead) return;
        
        isDead = true;
        deathCooldown = 1f;
        
        _animator.SetInteger("isDie", 1);
        
        planeGameManager.GameOver();
    }
}
