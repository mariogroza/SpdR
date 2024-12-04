using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private TutorialTextManager _tutorialTextManager;
    private Death _deathHandler;

    private int _currentStep = 0;
    private Vector2 _levelStartingPosition;

    [SerializeField]
    private string[] tutorialMessages =
    {
        "Hello! This is your helper SPDR. Use A and D to touch this totally not suspicious green rectangle!",
        "This one too!!",
        "Wow, you are a natural! You can also use SPACE to jump!",
        "Amazing job!! Combine these simple mechanics to get up to the green rectangle!",
        "That's impressive! Now head right to continue!",
        "Hold SPACE to climb the GREEN walls."
    };

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _deathHandler = GetComponent<Death>();
        _tutorialTextManager = GetComponentInChildren<TutorialTextManager>();

        _tutorialTextManager.helperText.text = tutorialMessages[_currentStep];
        _levelStartingPosition = _playerMovement.Rigidbody.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(_deathHandler.HandleDeath());
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(ReloadFirstScene());
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
        _playerMovement.Rigidbody.position = _levelStartingPosition;
    }

    private void LoadNextScene()
    {
        _levelStartingPosition = _playerMovement.Rigidbody.position;

        if (_currentStep < tutorialMessages.Length)
        {
            _currentStep++;
            _tutorialTextManager.helperText.text = tutorialMessages[_currentStep];
        }

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
