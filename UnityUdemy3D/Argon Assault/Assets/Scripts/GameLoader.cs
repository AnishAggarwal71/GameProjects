using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadNextLevel", 2f);
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
