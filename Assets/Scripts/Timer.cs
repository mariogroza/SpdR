using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI velocityText;
    
    public PlayerMovement pm;
    float elapsedTime;

    void Update()
    {
        //timer calculator
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt(elapsedTime * 1000f)/10 % 100;
        timerText.text = minutes + ":" + seconds + ":" + milliseconds;

        // Getting only int of velocty

        velocityText.text = Mathf.Abs(Mathf.Floor(pm.rb.linearVelocityX)).ToString();
    }
}
