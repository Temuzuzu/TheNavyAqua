using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor.PackageManager.Requests;

public class Timer : MonoBehaviour
{
    [Header("Timer UI Reference")]
    [SerializeField] private Image uiFilledImage;
    [SerializeField] private Text uiText;

    public int Duration { get; private set;}
    private int remainingDuration;

    private void Awake()
    {
        ResetTimer();
    }
    private void ResetTimer()
    {
        uiText.text = "00:00";
        uiFilledImage.fillAmount = 0f;
        Duration = remainingDuration = 0;
    }
    public Timer setDuration (int seconds)
    {
        Duration = remainingDuration = seconds;
        return this;
    }
    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }
    private IEnumerator UpdateTimer()
    {
        while (remainingDuration > 0)
        {
            UpdateUi(remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds (1f);
        }
        End();
    }
    private void UpdateUi(int seconds)
    {
        uiText.text = string.Format($"{0:D2}:{1:d2}", seconds / 60, seconds % 60);
        uiFilledImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
    }
    public void End()
    {
        ResetTimer ();
    }
    private void OnDestroy()
    {
        StopAllCoroutines(); 
    }
}
