using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void LoadScene(string NextScene)
    {
        SceneManager.LoadScene(NextScene);
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
