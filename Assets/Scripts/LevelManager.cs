using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Death deathHandler;

    private int currentStep;
    [HideInInspector]public Vector2 levelStartingPosition;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        deathHandler = GetComponent<Death>();
        levelStartingPosition = playerMovement.Rigidbody.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(deathHandler.HandleDeath());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            LoadNextScene();
        }
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Respawn()
    {
        playerMovement.Rigidbody.position = levelStartingPosition;
    }

    private void LoadNextScene()
    {
        levelStartingPosition = playerMovement.Rigidbody.position;

        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
        yield return new WaitForSeconds(0.1f);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator ReloadFirstScene()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
        yield return new WaitForSeconds(0.1f);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
