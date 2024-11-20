using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    private void Start()
    { 
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 600);
        int milliseconds = (int)(Time.timeSinceLevelLoad * 100f) % 100;
        timerText.text = minutes + "." + seconds + "." + milliseconds;
    }
}
