using System.Collections;
using UnityEngine;
using TMPro;

public class Death : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI deathCounterText;
    [SerializeField] private SpriteRenderer topRenderer;
    [SerializeField] private SpriteRenderer bottomRenderer;
    [SerializeField] private SpriteRenderer leftRenderer;
    [SerializeField] private SpriteRenderer rightRenderer;

    private LevelManager levelManager;
    private PlayerMovement playerMovement;
    private ParticleSystem deathParticles;

    private int deathCounter = 0;

    private void Start()
    {
        deathParticles = GetComponent<ParticleSystem>();
        levelManager = GetComponent<LevelManager>();
        playerMovement = GetComponent<PlayerMovement>();

        UpdateDeathCounterText();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" && (playerMovement.lastVelocityY > 45 || playerMovement.lastVelocityX > 45))
        {
            StartCoroutine(HandleDeath());
        }

        if (collision.gameObject.tag == "Death")
        {
            StartCoroutine(HandleDeath());
        }
    }
    
    private void SpawnParticles()
    {
        deathParticles.Play();
    }

    public IEnumerator HandleDeath()
    {
        SpawnParticles();

        FreezePlayer();

        yield return new WaitForSeconds(0.5f);

        RespawnPlayer();
        IncrementDeathCounter();
    }

    private void FreezePlayer()
    {
        playerMovement.Rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        SetPlayerRenderers(false);
    }

    private void RespawnPlayer()
    {
        levelManager.Respawn();
        playerMovement.Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        SetPlayerRenderers(true);
    }

    private void SetPlayerRenderers(bool enabled)
    {
        topRenderer.enabled = enabled;
        bottomRenderer.enabled = enabled;
        leftRenderer.enabled = enabled;
        rightRenderer.enabled = enabled;
    }

    private void IncrementDeathCounter()
    {
        deathCounter++;
        UpdateDeathCounterText();
    }

    private void UpdateDeathCounterText()
    {
        deathCounterText.text = $"Deaths:{deathCounter}";
    }
}
