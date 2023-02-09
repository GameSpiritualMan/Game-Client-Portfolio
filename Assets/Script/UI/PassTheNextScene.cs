using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassTheNextScene : MonoBehaviour
{
    public void SceneMove(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
}
