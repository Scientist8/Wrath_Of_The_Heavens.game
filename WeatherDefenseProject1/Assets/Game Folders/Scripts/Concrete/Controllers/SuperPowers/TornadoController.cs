using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoController : MonoBehaviour
{
    Rigidbody _rb;

    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] float _rotateY = 5f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        _rb.AddForce(new Vector3(_moveSpeed, 0, 0));
        
        transform.Rotate(0, _rotateY, 0);
        _rotateY++;
        Invoke("Destroy", 5f);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
