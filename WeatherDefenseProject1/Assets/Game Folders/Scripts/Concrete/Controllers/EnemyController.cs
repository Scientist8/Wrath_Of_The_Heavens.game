using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator _animator;

    [SerializeField] ParticleSystem _enemyDeathParticle;

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
        _animator = GetComponent<Animator>();

        _enemyHealthPoints = _enemy1HealthPoint + _enemy2HealthPoint + _enemy3HealthPoint + _enemy4HealthPoint;
        _scoreToGive = _enemy1Score + _enemy2Score + _enemy3Score + _enemy4Score;
        _moveSpeed = _moveSpeed1 + _moveSpeed2 + _moveSpeed3 + _moveSpeed4;
        _randomSpeedFactorZ = _randomSpeedFactorZ1 + _randomSpeedFactorZ2 + _randomSpeedFactorZ3 + _randomSpeedFactorZ4;
    }

    void Update()
    {
        Move();
        Die();
        PlayDeathParticleEffect();
    }

    void Die()
    {
        if (_enemyHealthPoints <= 0 || transform.position.y < -5)
        {
            _isDead = true;

            // Play death sound
            FindObjectOfType<AudioManager>().PlaySound("EnemyDeath");


            //Animator has no bool, just activates itself
            _animator.enabled = true;


            Invoke("IncreaseScore", 0.999f);
            //Invoke("PlayDeathParticleEffect", 0.9f);
            Invoke("DestroyThis", 1f);
        }
    }

    void Move()
    {
        if (!_isDead)
        {
            float xValue = Random.Range(-1f, -2f) * Time.deltaTime * _moveSpeed;
            float zValue = Random.Range(-_randomSpeedFactorZ, _randomSpeedFactorZ) * Time.deltaTime * _moveSpeed;

            transform.Translate(xValue, 0, zValue);


            _enemyDeathParticle.Stop();
        }
       
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }

    void PlayDeathParticleEffect()
    {
        if (_isDead)
        {
            if (!_enemyDeathParticle.isPlaying)
            {
                _enemyDeathParticle.Play();
            }
        }
        
    }

    void IncreaseScore()
    {
        GameManager.Instance.IncreaseScore(_scoreToGive);
    }
}
