using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject _mainMenu;
    public GameObject _selectLevelMenu;

    public void SelectLevelButton()
    {
        _mainMenu.SetActive(false);
        _selectLevelMenu.SetActive(true);
    }

    public void BackButton()
    {
        _mainMenu.SetActive(true);
        _selectLevelMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
