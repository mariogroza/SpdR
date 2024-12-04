using System.Collections;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TutorialTextManager : MonoBehaviour
{
    public TextMeshProUGUI helperText;

    public Death death;

    public string[] insults = { "Those who know are among us.", "Walking failure.", "Editor please switch to paint drying!!", "Wow you are bad at this.", "Can we get someone else at the keyboard please?", "Are you even trying?", "This gameplay would have hurt my eyes if I had any.", "You are a disgrace.", "You play like a blind cow.", "Monkeys will write Hamlet before you finish this game." };
    string text1 = "";
    public IEnumerator textSwapToMeanJokeAndBackRandom()
    {
        //save the current text in text1
        text1 = helperText.text;
        //randomize selection of mean stuff...
        int randomNumber = Random.Range(0, insults.Length);
        helperText.text = insults[randomNumber];

        //wait for user to read and swap back
        yield return new WaitForSeconds(4f);

        helperText.text = text1;
    }

}
