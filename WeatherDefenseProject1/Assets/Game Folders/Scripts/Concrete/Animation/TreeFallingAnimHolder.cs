using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFallingAnimHolder : MonoBehaviour
{
    Animator _animator;

    EnvironmentController _environmentController;


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _environmentController = FindObjectOfType<EnvironmentController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Castle")
        {
            _animator.enabled = true;
        }
    }
}
