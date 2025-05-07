using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [Range(1f, 20f)] [SerializeField] private float speed = 5f;
    [Range(10f, 30f)] [SerializeField] private float jumpForce = 15f;

    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }

    public float JumpForce
    {
        get => jumpForce;
        set => jumpForce = Mathf.Clamp(value, 10, 30);
    }
}
