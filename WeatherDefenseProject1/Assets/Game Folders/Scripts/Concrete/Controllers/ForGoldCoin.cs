using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForGoldCoin : MonoBehaviour
{
    Rigidbody _rb;

    public int _bonusToGive;
    public int _goldCoinCount = 1;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckGoldCoin();
        _rb.AddForce(new Vector3(Random.Range(-3, 3), -2, Random.Range(-2, 2)));
    }

    void CheckGoldCoin()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "GoldCoin")
                {
                    GameManager.Instance.IncreaseScore(_bonusToGive);
                    GameManager.Instance.IncreaseGoldCoin(_goldCoinCount);
                    //PlayerPrefs.DeleteKey("GoldCoin");

                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
