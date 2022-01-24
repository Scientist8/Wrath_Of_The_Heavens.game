using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleColorChanger : MonoBehaviour
{
    [SerializeField] CastleController _castleController;
    [SerializeField] MeshRenderer _renderer;

    private void Awake()
    {
        _castleController = GetComponentInParent<CastleController>();
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        _renderer.material.color = Color.Lerp(Color.gray, Color.blue, _castleController._castleHealth / 200f);
    }
}
