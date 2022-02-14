using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void ReloadLevel()
    {
        int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;       
        SceneManager.LoadScene(currenSceneIndex);

        //This next line has to change, it's copy + paste everywhere
        GameManager.Instance._score = 0;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.Instance._score = 0;
    }

    public void BackToMainMenu()
    {
        GameManager.Instance.GameResume();
        SceneManager.LoadScene("MainMenu");
        GameManager.Instance._score = 0;
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("EndScene");
        GameManager.Instance._score = 0;
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
        GameManager.Instance._score = 0;
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
        GameManager.Instance._score = 0;
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
        GameManager.Instance._score = 0;
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level4");
        GameManager.Instance._score = 0;
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level5");
        GameManager.Instance._score = 0;
    }
}
