using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWaveSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _wavePrefabs;

    public Transform _waveSpawner;

    public bool _lastWaveCame = false;

    public float _waveTimeInterval1 = 6.5f;
    public float _waveTimeInterval2 = 13f;
    public float _waveTimeInterval3 = 19.5f;
    public float _waveTimeInterval4 = 26f;

    private void Start()
    {
        Invoke("SpawnWave1", 1);
        Invoke("SpawnWave2", _waveTimeInterval1);
        Invoke("SpawnWave3", _waveTimeInterval2);
        Invoke("SpawnWave4", _waveTimeInterval3);
        Invoke("SpawnWave5", _waveTimeInterval4);
    }

    private void Update()
    {
        DestroyWave();
    }


    private void SpawnWave1()
    {
        Instantiate(_wavePrefabs[0], transform.position, Quaternion.identity, _waveSpawner);
    }

    private void SpawnWave2()
    {
        Instantiate(_wavePrefabs[1], transform.position, Quaternion.identity, _waveSpawner);
    }

    private void SpawnWave3()
    {
        Instantiate(_wavePrefabs[2], transform.position, Quaternion.identity, _waveSpawner);
    }

    private void SpawnWave4()
    {
        Instantiate(_wavePrefabs[3], transform.position, Quaternion.identity, _waveSpawner);
    }

    private void SpawnWave5()
    {
        Instantiate(_wavePrefabs[4], transform.position, Quaternion.identity, _waveSpawner);
        _lastWaveCame = true;
    }

    private void DestroyWave()
    {
        foreach (Transform child in transform)
        {
            if (child.transform.childCount <= 0)
            {
                Destroy(child.gameObject);
            }
        }

        //int childrenNumber1 = _wavePrefabs[0].transform.childCount;
        //    if (childrenNumber1 <= 0)
        //    {
        //    GameObject.Destroy(_wavePrefabs[0]);
        //    }
        //int childrenNumber2 = _wavePrefabs[1].transform.childCount;
        //    if (childrenNumber2 <= 0)
        //    {
        //    GameObject.Destroy(_wavePrefabs[1]);
        //    }
        //int childrenNumber3 = _wavePrefabs[2].transform.childCount;
        //    if (childrenNumber3 <= 0)
        //    {
        //    GameObject.Destroy(_wavePrefabs[2]);
        //    }
    }
}
