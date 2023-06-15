using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmunition_AmmunitionAction : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float shotSpeed, shootRange;
    [SerializeField] string gunName;
    [SerializeField] Vector3 direction;
    public static float damage { get; set; }
    public float SetDamage = 4.0f;
    
    void Start()
    {

        damage = SetDamage;
        shotSpeed = 13.0f;
        shootRange = 2.0f;
        rb = GetComponent<Rigidbody>();
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
        transform.Translate(direction);
    }
}
