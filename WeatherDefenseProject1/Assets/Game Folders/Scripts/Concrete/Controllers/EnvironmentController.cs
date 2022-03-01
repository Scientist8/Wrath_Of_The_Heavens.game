using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    public float _moveSpeed; //This will indicate the castle's movement speed


    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime, Space.World);
        ResetPosition();
    }

    private void ResetPosition()
    {
        if (transform.position.x <= -73f)
        {
            transform.position = new Vector3(0, 1.28f, 0);            

            //Invoke("DestroyThis", 0.5f);
        }
    }

    public bool _positionIsReseted()
    {
        if (transform.position.x <= -70)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }

}
