using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    PlayerMovement pm;
    Death Death;
    Vector2 levelStartingPosition = new Vector2 (0, 0);
    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
        Death = GetComponent<Death>();
        levelStartingPosition = pm.rb.position;
    }

    private void Update()
    {
        //Reset Scene

        if (Input.GetKeyDown(KeyCode.R))
           StartCoroutine(Death.DeathDelay());

        //Reset Run
        if (Input.GetKeyDown(KeyCode.T))
            StartCoroutine(FirstScene());
    }

    //Load next scene on colision with end of level
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Finish")
        {
            levelStartingPosition = pm.rb.position;
            StartCoroutine(NextScene());
        }
    }
    //NOT YET USED
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    IEnumerator NextScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
        yield return new WaitForSeconds(.1f);
        
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator FirstScene()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        yield return new WaitForSeconds(.1f);

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    //goes back to the start of the level on death
    public void Respawn()
    {
        pm.rb.position = levelStartingPosition;
    }
}
