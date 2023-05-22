using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAmmunition_Action : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float shotSpeed, shootRange;
    [SerializeField] Vector3 direction;
    public static float damage { get; set; }
    public float SetDamage = 4.0f;
    void Start()
    {
        damage = SetDamage;
        shotSpeed = 15.0f;
        shootRange = 2.0f;
        rb = GetComponent<Rigidbody>();
        transform.rotation = GameObject.Find("PlayerShip").transform.GetChild(0).rotation;
        Destroy(gameObject, shootRange);
    }

    void FixedUpdate() {
        Movement();
        //StartCoroutine(AmmoDestuction());
    }

    public void Movement()
    {
        direction = Vector3.forward * shotSpeed;
        //rb.AddForce(direction, ForceMode.Impulse);
        transform.Translate(direction, transform);
    }

    // public IEnumerator AmmoDestuction()
    // {
    //     yield return new WaitForSeconds(2.0f);
    //     Destroy(gameObject);
    // }
}
