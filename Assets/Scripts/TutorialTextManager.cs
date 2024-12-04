using System.Collections;
using TMPro;
using UnityEngine;

public class TutorialTextManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI helperText;
    [SerializeField] private Death death;

    private readonly string[] insults =
    {
        "Those who know are among us.",
        "Walking failure.",
        "Editor please switch to paint drying!!",
        "Wow you are bad at this.",
        "Can we get someone else at the keyboard please?",
        "Are you even trying?",
        "This gameplay would have hurt my eyes if I had any.",
        "You are a disgrace.",
        "You play like a blind cow.",
        "Monkeys will write Hamlet before you finish this game."
    };

    private string previousText = "";

    public IEnumerator SwapToMeanJokeAndBackRandom()
    {
        previousText = helperText.text;

        int randomIndex = Random.Range(0, insults.Length);
        helperText.text = insults[randomIndex];

        yield return new WaitForSeconds(4f);

        helperText.text = previousText;
    }
}
