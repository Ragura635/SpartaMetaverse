using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Transform player; // 플레이어 위치
    [SerializeField] private SpriteRenderer NPCRenderer;

    void Start()
    {
        NPCRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (player == null) return;

        // 플레이어가 오른쪽에 있으면 flipX 끔, 왼쪽이면 켬
        NPCRenderer.flipX = player.position.x < transform.position.x;
    }
}
