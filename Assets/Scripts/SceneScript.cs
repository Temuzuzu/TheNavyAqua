using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void EnterMainMenu()
    {
        Debug.Log("EnterMainMenu");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void EnterM1()
    {
        Debug.Log("EnterMap1");
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
