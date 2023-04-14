using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAmmunition : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float shotSpeed;

    void Start()
    {
        shotSpeed = 5;
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        rb.AddForce((Vector3.up * shotSpeed), ForceMode.Impulse);
        StartCoroutine(AmmoDestuction());  
    }

    public IEnumerator AmmoDestuction()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
