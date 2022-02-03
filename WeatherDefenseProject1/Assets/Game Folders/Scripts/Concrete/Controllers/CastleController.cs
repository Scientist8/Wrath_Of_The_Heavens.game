using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{
    GamePanelUI _gamePanel;

    LevelEnder _levelEnder;

    [SerializeField] ParticleSystem _successParticles;


    public int _castleHealth;

    public int _enemy1Damage;
    public int _enemy2Damage;
    public int _enemy3Damage;
    public int _enemy4Damage;

    private void Awake()
    {
        _gamePanel = FindObjectOfType<GamePanelUI>();
        _levelEnder = FindObjectOfType<LevelEnder>();
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy1":
                _castleHealth -= _enemy1Damage;
                break;
            case "Enemy2":
                _castleHealth -= _enemy2Damage;
                break;
            case "Enemy3":
                _castleHealth -= _enemy3Damage;
                break;
            case "Enemy4":
                _castleHealth -= _enemy4Damage;
                break;
        }
    }

    private void Update()
    {

        if (_castleHealth <= 0)
        {
            _gamePanel.ActivateFailMenu();
        }

        if (_levelEnder._levelHasEnded)
        {
            _successParticles.Play();
        }
    }


}
