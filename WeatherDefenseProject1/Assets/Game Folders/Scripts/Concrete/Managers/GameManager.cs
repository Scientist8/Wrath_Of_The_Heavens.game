using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool _gameIsPaused = false;

    public int _score = 0;
    public int _goldCoinCount = 0;


    public static GameManager Instance { get; private set; }


    void Awake()
    {
        SingletonThisGameObject();
    }

    private void Start()
    {
        _goldCoinCount = PlayerPrefs.GetInt("GoldCoin");
    }


    public void SingletonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void GamePause()
    {
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }

    public void GameResume()
    {
        Time.timeScale = 1f;
        _gameIsPaused = false;
    }

    public void IncreaseScore( int scoreToGive)
    {
        _score += scoreToGive;
    }

    public void IncreaseGoldCoin(int coinToGive)
    {
        _goldCoinCount += coinToGive;
        PlayerPrefs.SetInt("GoldCoin", _goldCoinCount);
    }
}
