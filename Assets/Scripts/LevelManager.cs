using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    PlayerMovement pm;
    Death Death;
    Vector3 levelStartingPosition = new Vector3(-4.22000027f, -0.449999809f, 0);
    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
        Death = GetComponent<Death>();
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
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
        yield return new WaitForSeconds(.1f);

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    //goes back to the start of the level on death
    public void Respawn()
    {
        pm.rb.position = levelStartingPosition;
    }
}
