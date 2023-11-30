using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
public float timeToFadeIn;
    public float timeToWait;
    public float timeToFadeOut;
    public CanvasGroup[] myUIGroup;

    private int currentDialogIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayDialogs());
    }

    IEnumerator PlayDialogs()
    {
        while (currentDialogIndex < myUIGroup.Length)
        {
            // Fade In
            yield return StartCoroutine(Fade(myUIGroup[currentDialogIndex], true, timeToFadeIn));

            // Wait
            yield return new WaitForSeconds(timeToWait);

            // Fade Out
            yield return StartCoroutine(Fade(myUIGroup[currentDialogIndex], false, timeToFadeOut));

            // Move to the next dialog
            currentDialogIndex++;
        }

        // All dialogs played, you can load the next scene here if needed.
    }

    IEnumerator Fade(CanvasGroup canvasGroup, bool fadeIn, float time)
    {
        float startAlpha = fadeIn ? 0 : 1;
        float endAlpha = fadeIn ? 1 : 0;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = endAlpha;
    }}
