using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleMeteoriteController : MonoBehaviour
{
    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Invoke("Destroy", 1f);
    }

    void Update()
    {
        //_rb.AddForce(new Vector3(5, 0, 5) * Random.Range(-2, 2));
        _rb.AddForce(new Vector3(Random.Range(-50, 50), 0, Random.Range(-100, 100)));
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
