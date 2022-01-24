using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnder : MonoBehaviour
{
    GameObject _waveSpawnerObject;
    NewWaveSpawner _waveSpawnerScript;
    LevelManager _levelManager;

    public bool _levelHasEnded = false;

    private void Awake()
    {
        _waveSpawnerObject = GameObject.Find("WaveSpawner");
        _waveSpawnerScript = FindObjectOfType<NewWaveSpawner>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        NextLevel();
    }

    void NextLevel()
    {
        if (_waveSpawnerObject.transform.childCount <= 0 && _waveSpawnerScript._lastWaveCame == true)
        {
            _levelHasEnded = true;
        }
    }
}
