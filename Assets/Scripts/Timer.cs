using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public PlayerMovement playerMovement;

    private float elapsedTime;

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt(elapsedTime * 1000f) / 10 % 100;

        timerText.text = $"{minutes:00}:{seconds:00}:{milliseconds:00}";
    }
}