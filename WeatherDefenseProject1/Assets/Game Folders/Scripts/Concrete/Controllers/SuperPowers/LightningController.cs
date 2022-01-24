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
        _rb.AddForce(new Vector3(Random.Range(-3, 3), -2, Random.Range(-2, 2)));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
