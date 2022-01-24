using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int _enemyHealthPoints;
    public int _enemy1HealthPoint, _enemy2HealthPoint, _enemy3HealthPoint, _enemy4HealthPoint;

    public int _scoreToGive;
    public int _enemy1Score, _enemy2Score, _enemy3Score, _enemy4Score;

    public bool _isDead = false;

    [SerializeField] float _moveSpeed;
    public float _moveSpeed1, _moveSpeed2, _moveSpeed3, _moveSpeed4;

    [SerializeField] float _randomSpeedFactorZ = 1.5f;
    public float _randomSpeedFactorZ1, _randomSpeedFactorZ2, _randomSpeedFactorZ3, _randomSpeedFactorZ4;

    void Awake()
    {
        _enemyHealthPoints = _enemy1HealthPoint + _enemy2HealthPoint + _enemy3HealthPoint + _enemy4HealthPoint;
        _scoreToGive = _enemy1Score + _enemy2Score + _enemy3Score + _enemy4Score;
        _moveSpeed = _moveSpeed1 + _moveSpeed2 + _moveSpeed3 + _moveSpeed4;
        _randomSpeedFactorZ = _randomSpeedFactorZ1 + _randomSpeedFactorZ2 + _randomSpeedFactorZ3 + _randomSpeedFactorZ4;
    }

    void Update()
    {
        Move();
        Die();
    }

    void Die()
    {
        if (_enemyHealthPoints == 0 || transform.position.y < -5)
        {
            _isDead = true;
            GameManager.Instance.IncreaseScore(_scoreToGive);
            Destroy(gameObject);
        }
    }

    void Move()
    {
        float xValue = Random.Range(-1f, -2f) * Time.deltaTime * _moveSpeed;
        float zValue = Random.Range(-_randomSpeedFactorZ, _randomSpeedFactorZ) * Time.deltaTime * _moveSpeed;

        transform.Translate(xValue, 0, zValue);
    }
}
