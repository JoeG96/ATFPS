using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageMenu : MonoBehaviour
{


    [Header("Button Canvases")]
    [SerializeField] GameObject levelSelectCanvas;
    [SerializeField] GameObject mainMenuCanvas;


    void Start()
    {
        mainMenuCanvas.SetActive(true);
        levelSelectCanvas.SetActive(false);
    }


    public void EnableMainMenuButtons()
    {
        mainMenuCanvas.SetActive(true);
    }

    public void DisableMainMenuButtons()
    {
        mainMenuCanvas.SetActive(false);
    }

    public void EnableLevelSelectButtons()
    {
        levelSelectCanvas.SetActive(true);
    }

    public void DisableLevelSelectButtons()
    {
        levelSelectCanvas.SetActive(false);
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void OpenLevelSelect()
    {
        DisableMainMenuButtons();
        EnableLevelSelectButtons();
    }

    public void OpenMainMenu()
    {
        DisableLevelSelectButtons();
        EnableMainMenuButtons();
    }

}
