using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    LevelManager lm;
    PlayerMovement pm;
    private ParticleSystem death;
    public SpriteRenderer top,bottom,left,right;

    private void Start()
    {
        death = GetComponent<ParticleSystem>();
        lm = GetComponent<LevelManager>();
        pm = GetComponent<PlayerMovement>();
    }

    // Death by velocity
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (Mathf.Abs(pm.lastVel) > 5)
            {
                StartCoroutine(DeathDelay());
            }
        }
    }
    //Particle Spawner
    public void SpawnParticles()
    {
        death.Play();
    }
    //Death and deathDelay
    IEnumerator DeathDelay()
    {
        //Freezing movement and turning of player rendering
        SpawnParticles();
        pm.rb.constraints = RigidbodyConstraints2D.FreezeAll;
        top.enabled = false;
        bottom.enabled = false;
        left.enabled = false;
        right.enabled = false;

        yield return new WaitForSeconds(.5f);
        
        //turning them back on
        lm.Respawn();
        top.enabled = true;
        bottom.enabled = true;
        left.enabled = true;
        right.enabled = true;
        pm.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}