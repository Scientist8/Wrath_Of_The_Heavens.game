using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePanelUI : MonoBehaviour
{
    public static bool _gameIsPaused = false;

    public GameObject _pauseMenuPanel;

    public Text _gameScoreText;
    public Text _goldCoinText;

    public void ResumeGame()
    {
        _pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
    }

    public void PauseGame()
    {
        _pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }

    void Update()
    {
        _gameScoreText.text = GameManager.Instance._score.ToString();
        _goldCoinText.text = "Gold: " + GameManager.Instance._goldCoinCount.ToString();
    }
}
