using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    Collider _collider;
    Renderer _renderer;
    Rigidbody _rb;

    [SerializeField] GameObject _littleMeteoritePrefab;

    void Update()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();

        _rb.AddForce(new Vector3(2, -15, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        _collider.enabled = false;
        _renderer.enabled = false;
        SpawnLittleMeteorite();

        Invoke("Destroy", 0.5f);

    }

    void SpawnLittleMeteorite()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(_littleMeteoritePrefab, transform.position, Quaternion.identity);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
