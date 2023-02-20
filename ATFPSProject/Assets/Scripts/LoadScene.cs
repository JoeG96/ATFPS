using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
  

    public void LoadTheScene(string levelToLoad)
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(levelToLoad);
    }
}
