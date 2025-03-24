using UnityEngine;

public class CrosshairFollowMouse : MonoBehaviour
{
    private Vector3 crosshair;
    private Vector3 worldMousePos;

    public void Start()
    {  
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        crosshair = Input.mousePosition;
        crosshair.z = 1;
        
        worldMousePos = Camera.main.ScreenToWorldPoint(crosshair);
        
        transform.position = worldMousePos;
    }

}
