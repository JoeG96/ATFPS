using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private ScoreManager scoreManager;
    public float levelScore;

    public bool levelFinished;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject WeaponCanvas;
    [SerializeField] GameObject UICanvas;
    public bool isPaused = false;

    [SerializeField] GameObject player;

    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreManager.ResetCurrentLevelScore();

        player = GameObject.Find("Player");

        levelFinished = false;
    }


    void Update()
    {
        if (levelFinished)
        {
            UpdateScoreManager();
        }
    }

    public void UpdateScoreManager()
    {
        scoreManager.SetLevelScore("Level1", levelScore);
    }

    public void AddToCurrentScore(float scoreToAdd)
    {
        levelScore += scoreToAdd;
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        WeaponCanvas.SetActive(false);
        UICanvas.SetActive(false);
        player.GetComponent<GunManager>().enabled = false;
        player.GetComponent<PlayerMotor>().enabled = false;
        player.GetComponent<PlayerLook>().enabled = false;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        WeaponCanvas.SetActive(true);
        UICanvas.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(Delay(1f));
        player.GetComponent<GunManager>().enabled = true;
        player.GetComponent<PlayerMotor>().enabled = true;
        player.GetComponent<PlayerLook>().enabled = true;
        
        
    }

    public IEnumerator Delay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
