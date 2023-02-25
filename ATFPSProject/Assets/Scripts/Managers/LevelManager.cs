using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private ScoreManager scoreManager;
    public float levelScore;

    public bool levelFinished;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject WeaponCanvas;
    [SerializeField] GameObject UICanvas;
    [SerializeField] GameObject GameWinCanvas;

    public TextMeshProUGUI scoreText;

    public bool isPaused = false;

    [SerializeField] GameObject player;

    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreManager.ResetCurrentLevelScore();

        player = GameObject.Find("Player");
        
        levelFinished = false;
        GameWinCanvas.SetActive(false); ;
    }


    void Update()
    {
        if (levelFinished)
        {
            UpdateScoreManager();
            LevelWinScreen();
        }
    }

    public void UpdateScoreManager()
    {
        scoreManager.SetLevelScore(GetCurrentLevel(), levelScore);
        scoreText.text = levelScore.ToString();
    }

    public void AddToCurrentScore(float scoreToAdd)
    {
        levelScore += scoreToAdd;
    }

    public string GetCurrentLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        string currentLevel = scene.name;
        return currentLevel;
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

    public void SetLevelWon()
    {
        levelFinished = true;
    }

    public void LevelWinScreen()
    {


        GameWinCanvas.SetActive(true);
        pauseMenu.SetActive(false);
        WeaponCanvas.SetActive(false);
        UICanvas.SetActive(false);
        player.GetComponent<GunManager>().enabled = false;
        player.GetComponent<PlayerMotor>().enabled = false;
        player.GetComponent<PlayerLook>().enabled = false;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;


    }
}
