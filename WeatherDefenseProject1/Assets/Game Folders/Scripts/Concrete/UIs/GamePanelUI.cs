using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePanelUI : MonoBehaviour
{
    public GameObject _pauseMenuPanel;
    public GameObject _endLevelMenu;
    public GameObject _failMenu;

    public Text _gameScoreText;
    public Text _goldCoinText;

    public Text _endLevelScoreText;
    public Text _endLevelGoldText;

    public Text _failMenuScoreText;
    public Text _failMenuGoldText;

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
        _goldCoinText.text = "x" + GameManager.Instance._goldCoinCount.ToString();

        _endLevelScoreText.text = "Score: " + GameManager.Instance._score.ToString();
        _endLevelGoldText.text = "Gold: " + GameManager.Instance._goldCoinCount.ToString();

        _failMenuScoreText.text = "Score: " + GameManager.Instance._score.ToString();
        _failMenuGoldText.text = "Gold: " + GameManager.Instance._goldCoinCount.ToString();
    }

    public void ActivateEndLevelMenu()
    {
        this.gameObject.SetActive(false);
        _endLevelMenu.SetActive(true);
    }

    public void ActivateFailMenu()
    {
        this.gameObject.SetActive(false);
        _failMenu.SetActive(true);
    }
}
