using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnder : MonoBehaviour
{
    GameObject _waveSpawnerObject;
    NewWaveSpawner _waveSpawnerScript;

    public bool _levelHasEnded = false;

    private void Awake()
    {
        
    }

    void Update()
    {
        _waveSpawnerObject = GameObject.Find("WaveSpawner");
        _waveSpawnerScript = FindObjectOfType<NewWaveSpawner>();

        CheckingForLevelEnd();
    }

    void CheckingForLevelEnd()
    {
        if (_waveSpawnerObject.transform.childCount <= 0 && _waveSpawnerScript._lastWaveCame == true)
        {
            _levelHasEnded = true;
        }
    }
}
