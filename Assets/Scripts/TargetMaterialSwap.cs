using System;
using UnityEngine;

public class TargetMaterialSwap : MonoBehaviour
{
    public PhysicsMaterial2D normalMaterial;
    public PhysicsMaterial2D bounceMaterial;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && boxCollider.sharedMaterial == normalMaterial)
        {
            boxCollider.sharedMaterial = bounceMaterial;
            spriteRenderer.color = Color.magenta;
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.F) && boxCollider.sharedMaterial == bounceMaterial)
            {
                boxCollider.sharedMaterial = normalMaterial;
                spriteRenderer.color = Color.white;
            }   
        }

        
    }
}
