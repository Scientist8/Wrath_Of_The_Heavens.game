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

        for (int i = 0; i < _enemyController.Length; i++)
        {
            _enemyController[i]._enemyHealthPoints--;
        }
    }

    public void LightningStorm()
    {
        for (int i = 0; i < Random.Range(15, 40); i++)
        {
            Instantiate(_lightningStormPrefab, new Vector3(Random.Range(-10, 10), transform.position.y, Random.Range(-2, 2)), Quaternion.identity);
        }

        for (int i = 0; i < _enemyController.Length; i++)
        {
            _enemyController[i]._enemyHealthPoints--;
        }
    }

    public void Tornado()
    {
        Instantiate(_tornadoPrefab, new Vector3 (-20, 3, 0), Quaternion.identity);

        for (int i = 0; i < _enemyController.Length; i++)
        {
            _enemyController[i]._enemyHealthPoints--;
        }
    }

    public void EarthQuake()
    {
        _cameraShaker.ShakeIt();

        for (int i = 0; i < _enemyController.Length; i++)
        {
            _enemyController[i]._enemyHealthPoints--;
        }
    }
}
