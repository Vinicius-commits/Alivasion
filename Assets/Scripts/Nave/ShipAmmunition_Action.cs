using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAmmunition_Action : MonoBehaviour
{
    // [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 direction;
    public static float damage;

    void Start()
    {
        damage = 1.0f;
        // shotSpeed = 15.0f;
        // shootRange = 0.50f;
        // rb = GetComponent<Rigidbody>();
        transform.rotation = GameObject.Find(GameManager.shipType).transform.GetChild(0).rotation;
        Destroy(gameObject, Shooter.shotRange);
    }

    void FixedUpdate() {
        Movement();
        //StartCoroutine(AmmoDestuction());
    }

    public void Movement()
    {
        direction = Vector3.forward * Shooter.shotSpeed;
        //rb.AddForce(direction, ForceMode.Impulse);
        transform.Translate(direction, transform);
    }

    // public IEnumerator AmmoDestuction()
    // {
    //     yield return new WaitForSeconds(2.0f);
    //     Destroy(gameObject);
    // }
}
