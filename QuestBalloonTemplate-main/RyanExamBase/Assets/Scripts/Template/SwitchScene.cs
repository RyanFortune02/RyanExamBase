using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void LoadScene(int index) 
    {
        SceneManager.LoadScene(index);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadNextScene() 
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        index = (index + 1) % SceneManager.sceneCountInBuildSettings;
        LoadScene(index);
    }
}
