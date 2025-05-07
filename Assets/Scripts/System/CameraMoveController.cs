using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour
{
    public Transform target;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    private Camera cam;
    
    // Start is called before the first frame update
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (target == null) return;

        float clampedX = Mathf.Clamp(target.position.x, minPosition.x, maxPosition.x);
        float clampedY = Mathf.Clamp(target.position.y, minPosition.y, maxPosition.y);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
