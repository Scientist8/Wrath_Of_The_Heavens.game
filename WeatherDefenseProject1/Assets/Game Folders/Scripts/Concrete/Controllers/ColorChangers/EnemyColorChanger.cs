using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColorChanger : MonoBehaviour
{
    [SerializeField] EnemyController _enemyController;
    [SerializeField] MeshRenderer _renderer;

    private void Awake()
    {
        _enemyController = GetComponentInParent<EnemyController>();
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        _renderer.material.color = Color.Lerp(Color.gray, Color.red, _enemyController._enemyHealthPoints / 15f);
    }
}
