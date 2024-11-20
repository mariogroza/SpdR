using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public PlayerMovement pm;
     private Vector2 lastVelocity;

     private Vector3 offset = new Vector3(0f, 0f, -10f);
     private Vector3 velocity = Vector3.zero;

     public float zoomVelocity = 0f;
     private float zoom;
     private float minZoom = 8f;
     private float maxZoom = 12f;

    [SerializeField] private Transform target;
    [SerializeField] private Camera cam;

    private void Start()
    {
        zoom = cam.orthographicSize;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }


    void FixedUpdate()
     {
        // zoom speed
        if (Mathf.Abs(pm.rb.linearVelocity.x) > Mathf.Abs(lastVelocity.x))   
            zoom += Mathf.Abs(pm.rb.linearVelocity.x)/100;
        else
            if (Mathf.Abs(pm.rb.linearVelocity.x) <= Mathf.Abs(lastVelocity.x))
                zoom -= 1;
            
        lastVelocity = pm.rb.linearVelocity;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);


        Vector3 targetPosition = target.position + offset;
        //camera follow
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0f);
        //zoom
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref zoomVelocity, 0.25f);
    }
}
