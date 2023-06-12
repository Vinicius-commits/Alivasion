using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOVNI_TripleGun : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    public bool canShoot = true;
    [SerializeField] float cadency, timing;
    void Start()
    {
        cadency = 1.70f;
        timing = 0;
    }

    void FixedUpdate()
    {
        RotateToAim(GameObject.Find("PlayerShip_StrongShip"));
        Shoot();

    }

    public void RotateToAim(GameObject toTake)
    {
        Vector3 takePos = toTake.transform.position;
        Vector3 worldTakePos = Camera.main.ScreenToWorldPoint(takePos);
        Vector3 dir = worldTakePos - transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }

    public void Shoot()
    {
        if(canShoot)
            canShoot = false;
            Instantiate(ammo, transform.position, transform.rotation);
            timing += Time.deltaTime;
        if(Time.deltaTime >= cadency)
        {
            canShoot = true;
            timing = 0;
        }
    }
}
