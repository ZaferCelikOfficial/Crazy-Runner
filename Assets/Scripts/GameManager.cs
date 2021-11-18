using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool isGameStarted;
    public static bool isGameEnded;

    public GameObject LevelCompletedPanel, LevelFailedPanel;
    public List<GameObject> Levels = new List<GameObject>();
    [SerializeField] int LevelIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            CreateLevel();
        }
    }
    public void CreateLevel()
    {
        LevelIndex = PlayerPrefs.GetInt("LevelNo", 0);
        if (LevelIndex > Levels.Count - 1)
        {
            LevelIndex = 0;
            PlayerPrefs.GetInt("LevelNo", 0);
        }
        Instantiate(Levels[LevelIndex]);
    }
    public void StartGame()
    {
        isGameStarted = true;
        isGameEnded = false;
    }
    public void EndGame()
    {
        isGameEnded = true;
    }
    public void OnLevelCompleted()
    {
        LevelCompletedPanel.SetActive(true);
    }
    public void OnLevelFailed()
    {
        LevelFailedPanel.SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGameStarted = false;
    }
    public void NextLevel()
    {
        LevelIndex++;
        PlayerPrefs.SetInt("LevelNo", LevelIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGameStarted = false;
    }
}
