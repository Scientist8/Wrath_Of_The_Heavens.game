using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePanelUI : MonoBehaviour
{
    public GameObject _pauseMenuPanel;

    public Text _gameScoreText;
    public Text _goldCoinText;

    public void ResumeGame()
    {
        _pauseMenuPanel.SetActive(false);
        GameManager.Instance.GameResume();
    }

    public void PauseGame()
    {
        _pauseMenuPanel.SetActive(true);
        GameManager.Instance.GamePause();
    }

    void Update()
    {
        _gameScoreText.text = GameManager.Instance._score.ToString();
        _goldCoinText.text = "Gold: " + GameManager.Instance._goldCoinCount.ToString();
    }
}
