using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator _animator;

    [SerializeField] ParticleSystem _enemyDeathParticle;

    public int _enemyHealthPoints;

    public int _scoreToGive;

    public bool _isDead = false;

    [SerializeField] float _moveSpeed;

    [SerializeField] float _randomSpeedFactorZ = 1.5f;

    void Awake()
    {
        _animator = GetComponent<Animator>();
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
            float xValue = -1 * Time.deltaTime * _moveSpeed;
            float zValue = Random.Range(-_randomSpeedFactorZ, _randomSpeedFactorZ) * Time.deltaTime;

            transform.position += new Vector3(xValue, 0, zValue);

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
