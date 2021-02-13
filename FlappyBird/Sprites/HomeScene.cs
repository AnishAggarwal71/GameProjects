using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
   
    public void LoadSceneOnClick(int i)
    {
        SceneManager.LoadScene(i);
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

}
