using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera cam;
    private const string LastX = "LastX";
    private const string LastY = "LastY";
    
    protected override void Start()
    {
        if (PlayerPrefs.HasKey(LastX))
        {
            float x = PlayerPrefs.GetFloat(LastX);
            float y = PlayerPrefs.GetFloat(LastY);

            transform.position = new Vector2(x, y);
        }
        
        base.Start();
        cam = Camera.main;
    }   

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        movementDirection = new Vector2(horizontal, 0).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = cam.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            Jump();
        }
    }
}
