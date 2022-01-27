using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugAndCheatMenu : MonoBehaviour
{
    public GameObject _gamePlayScreen;
    public GameObject _pauseMenu;
    public GameObject[] _pages;

    public ButtonController _buttonController;
    public CastleController _castleController;
    public ForGoldCoin _goldCoin;
    public GoldCoinSpawner _goldCoinSpawner;



    private int _clickCount = 0;

    //page1 slider texts
    public Text cameraXText, cameraYText, cameraZText, meteorText, lightningText, tornadoText, earthquakeText;
    //page2 slider texts
    public Text enemy1DamageText, enemy2DamageText, enemy3DamageText, enemy4DamageText, castleHealthText, goldCoinBonusText;
    public Text goldCoinMaxText, goldCoinMinText;



    private void Awake()
    {
        _buttonController = FindObjectOfType<ButtonController>();
        _castleController = FindObjectOfType<CastleController>();
        _goldCoin = FindObjectOfType<ForGoldCoin>();
        _goldCoinSpawner = FindObjectOfType<GoldCoinSpawner>();
    }

    private void Update()
    {
        cameraXText.text = "X: " + Camera.main.transform.position.x.ToString();
        cameraYText.text = "Y: " + Camera.main.transform.position.y.ToString();
        cameraZText.text = "Z: " + Camera.main.transform.position.z.ToString();

        meteorText.text = _buttonController._meteorDamage.ToString();
        lightningText.text = _buttonController._lightningDamage.ToString();
        tornadoText.text = _buttonController._tornadoDamage.ToString();
        earthquakeText.text = _buttonController._earthquakeDamage.ToString();

        enemy1DamageText.text = _castleController._enemy1Damage.ToString();
        enemy2DamageText.text = _castleController._enemy2Damage.ToString();
        enemy3DamageText.text = _castleController._enemy3Damage.ToString();
        enemy4DamageText.text = _castleController._enemy4Damage.ToString();

        castleHealthText.text = _castleController._castleHealth.ToString();

        goldCoinBonusText.text = _goldCoin._bonusToGive.ToString();

        goldCoinMaxText.text = _goldCoinSpawner._maxGoldCoin.ToString();
        goldCoinMinText.text = _goldCoinSpawner._minGoldCoin.ToString();

    }

    public void ActivateMenuWithClicking()
    {
        _clickCount++;

         if (_clickCount == 6)
         {
             _gamePlayScreen.SetActive(false);
            _pauseMenu.SetActive(false);
             this.gameObject.SetActive(true);

            GameManager.Instance.GamePause();

             _clickCount = 0;
         }
    }

    public void CloseThisMenu()
    {
        _gamePlayScreen.SetActive(true);
        _pauseMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ChangePage12()
    {
        _pages[0].SetActive(false);
        _pages[1].SetActive(true);
    }

    public void ChangePage21()
    {
        _pages[1].SetActive(false);
        _pages[0].SetActive(true);
    }

    public void ChangePage23()
    {
        _pages[1].SetActive(false);
        _pages[2].SetActive(true);
    }

    public void ChangePage32()
    {
        _pages[2].SetActive(false);
        _pages[1].SetActive(true);
    }


    public void ChangeCameraPositionX(float posX)
    {
        Camera.main.transform.position = new Vector3(posX, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }
    public void ChangeCameraPositionY(float posY)
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, posY, Camera.main.transform.position.z);
    }
    public void ChangeCameraPositionZ(float posZ)
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, posZ);
    }

    public void SetMeteorDamage(float newMeteorDamage)
    {
        _buttonController._meteorDamage = (int) newMeteorDamage;
    }

    public void SetLightningDamage(float newLightningDamage)
    {
        _buttonController._lightningDamage = (int)newLightningDamage;
    }

    public void SetTornadoDamage(float newTornadoDamage)
    {
        _buttonController._tornadoDamage = (int) newTornadoDamage;
    }

    public void SetEarthquakeDamage(float newEarthquakeDamage)
    {
        _buttonController._earthquakeDamage = (int) newEarthquakeDamage;
    }

    public void SetEnemy1Damage (float newEnemy1Damage)
    {
        _castleController._enemy1Damage =(int) newEnemy1Damage;
    }

    public void SetEnemy2Damage(float newEnemy2Damage)
    {
        _castleController._enemy2Damage = (int) newEnemy2Damage;
    }

    public void SetEnemy3Damage(float newEnemy3Damage)
    {
        _castleController._enemy3Damage = (int) newEnemy3Damage;
    }

    public void SetEnemy4Damage(float newEnemy4Damage)
    {
        _castleController._enemy4Damage = (int) newEnemy4Damage;
    }

    public void SetCastleHealthPoint(float newCastleHealth)
    {
        _castleController._castleHealth = (int) newCastleHealth;
    }

    public void SetGoldCoinBonus(float newGoldCoinBonus)
    {
        _goldCoin._bonusToGive =(int) newGoldCoinBonus;
    }

    public void SetGoldCoinMin(float newMinGoldCoin)
    {
        _goldCoinSpawner._minGoldCoin = (int)newMinGoldCoin;
    }

    public void SetGoldCoinMax(float newMaxGoldCoin)
    {
        _goldCoinSpawner._maxGoldCoin = (int)newMaxGoldCoin;
    }
}
