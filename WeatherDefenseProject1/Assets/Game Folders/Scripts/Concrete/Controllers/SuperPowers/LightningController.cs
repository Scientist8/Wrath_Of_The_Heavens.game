using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //_rb.AddForce(new Vector3(Random.Range(-3, 3), -5, Random.Range(-2, 2)));
        _rb.AddForce(new Vector3(0, -10, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
