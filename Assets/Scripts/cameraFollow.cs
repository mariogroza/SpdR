using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Player and Camera")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Transform target;
    [SerializeField] private Camera cam;

    [Header("Zoom Settings")]
    [SerializeField] private float minZoom = 8f;
    [SerializeField] private float maxZoom = 12f;
    private float zoomVelocity = 0f;
    private float currentZoom;

    [Header("Camera Movement")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;

    private Vector2 lastVelocity;

    private void Start()
    {
        currentZoom = cam.orthographicSize;
        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        UpdateZoom();
        FollowTarget();
    }

    private void UpdateZoom()
    {
        float playerSpeed = Mathf.Abs(playerMovement.Rigidbody.linearVelocity.x);

        if (playerSpeed > Mathf.Abs(lastVelocity.x))
        {
            currentZoom += playerSpeed / 100f;
        }
        else if (playerSpeed <= Mathf.Abs(lastVelocity.x))
        {
            currentZoom -= 1f;
        }

        lastVelocity = playerMovement.Rigidbody.linearVelocity;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, currentZoom, ref zoomVelocity, 0.25f);
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0f);
    }
}
