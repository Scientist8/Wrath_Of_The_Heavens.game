using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    EnemyController[] _enemyController;
    CameraShaker _cameraShaker;

    [SerializeField] GameObject _meteorPrefab;
    [SerializeField] GameObject _lightningStormPrefab;
    [SerializeField] GameObject _tornadoPrefab;

    public int _meteorDamage = 1;
    public int _lightningDamage = 1;
    public int _tornadoDamage = 1;
    public int _earthquakeDamage = 1;

    private void Awake()
    {
        _cameraShaker = FindObjectOfType<CameraShaker>();

    }

    private void Update()
    {
        _enemyController = FindObjectsOfType<EnemyController>();

    }

    public void Meteor()
    {
        Instantiate(_meteorPrefab, transform.position, Quaternion.identity);

        AudioManager.instance.PlaySound("Meteor");

        for (int i = 0; i < _enemyController.Length; i++)
        {
            _enemyController[i]._enemyHealthPoints -= _meteorDamage;
        }
    }

    public void LightningStorm()
    {
        AudioManager.instance.PlaySound("Lightning");

        for (int i = 0; i < Random.Range(30, 50); i++)
        {
            Instantiate(_lightningStormPrefab, new Vector3(Random.Range(-10, 15), transform.position.y, Random.Range(-6, 6)), Quaternion.identity);
        }

        for (int i = 0; i < _enemyController.Length; i++)
        {
            _enemyController[i]._enemyHealthPoints -= _lightningDamage;
        }
    }

    public void Tornado()
    {
        Instantiate(_tornadoPrefab, new Vector3 (-10, -2.5f, 0), Quaternion.identity);

        AudioManager.instance.PlaySound("Tornado");

        for (int i = 0; i < _enemyController.Length; i++)
        {
            _enemyController[i]._enemyHealthPoints -= _tornadoDamage;
        }
    }

    public void EarthQuake()
    {
        _cameraShaker.ShakeIt();

        AudioManager.instance.PlaySound("Earthquake");

        for (int i = 0; i < _enemyController.Length; i++)
        {
            _enemyController[i]._enemyHealthPoints -= _earthquakeDamage;
        }
    }
}
