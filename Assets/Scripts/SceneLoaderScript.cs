using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    public Animator transition;
    [SerializeField] private float _transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);


        SceneManager.LoadScene(levelIndex);
    }
}
