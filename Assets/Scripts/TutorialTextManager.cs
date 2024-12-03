using System.Collections;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialTextManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI helperText;
    int hasWalked = 0;
    int hasJumped = 0;

    public Death death;

    string text = "Hello! this is your helper SPDR, use A and D to move.",text1 = "";

    private void Start()
    {
        helperText.text = text;
    }
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && hasWalked == 0)
        {
            // nextText
            text = "Wow, you are a natural, you can also use SPACE to jump!";
            helperText.text = text;
            // happens only once
            hasWalked++;
            // give player time to read
            StartCoroutine(timeToRead());
        }
        if (Input.GetKeyDown(KeyCode.Space) && hasJumped == 0)
        {
            // nextText
            text = "Amazing job!! Head right to start the first level!";
            helperText.text = text;
            // happens only once
            hasJumped++;
            // give player time to read
            StartCoroutine(timeToRead());
        }
        if (hasJumped == 1 && hasWalked == 0)
        {
            // nextText
            text = "Obey the tutorial dog.";
            helperText.text = text;
            // happens only once
            StartCoroutine(timeToRead()); 
        }
    }
    IEnumerator timeToRead()
    {
        yield return new WaitForSeconds(4f);
        helperText.text = "";
    }
    public IEnumerator textSwapToMeanJokeAndBackRandom()
    {
        text1 = text;
        int randomNumber = Random.Range(1, 11);


        if (randomNumber == 1)
            text = "Wow you are bad at this.";
        if (randomNumber == 2)
            text = "Can we get someone else at the keyboard please?";
        if (randomNumber == 3)
            text = "Are you even trying?";
        if (randomNumber == 4)
            text = "This gameplay would have hurt my eyes if I had any.";
        if (randomNumber == 5)
            text = "You are a disgrace.";
        if (randomNumber == 6)
            text = "You play like a blind cow.";
        if (randomNumber == 7)
            text = "Monkeys will write Hamlet before you finish this game.";
        if (randomNumber == 8)
            text = "Editor please switch to paint drying!!";
        if (randomNumber == 9)
            text = "Walking failure.";
        if (randomNumber == 10)
            text = "Those who know are among us.";

        helperText.text = text;

        yield return new WaitForSeconds(4f);

        text = text1;

        helperText.text = text;
    }

}
