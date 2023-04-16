using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_ShipAmmunition : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float shotSpeed;
    [SerializeField] Vector3 direction;

    void Start()
    {
        shotSpeed = 5.0f;
        rb = GetComponent<Rigidbody>();
        transform.rotation = GameObject.Find("PlayerShip").transform.GetChild(0).rotation;
    }

    void Update() {
        Movement();
        StartCoroutine(AmmoDestuction());  
    }

    public void Movement()
    {
        direction = Vector3.forward * shotSpeed;
        //rb.AddForce(direction, ForceMode.Impulse);
        transform.Translate(direction, transform);
    }

    public IEnumerator AmmoDestuction()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
