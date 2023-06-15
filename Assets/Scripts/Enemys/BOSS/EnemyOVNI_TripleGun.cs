using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOVNI_TripleGun : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] Transform aim, projectilesSave;
    public bool canShoot = true;
    [SerializeField] float cadency, timing;
    void Start()
    {
        aim = transform.GetChild(0);
        cadency = 1.70f;
        timing = 0;
        projectilesSave = GameObject.Find("ProjectilesEnemy").transform;
    }

    void FixedUpdate()
    {
        RotateToAim(GameObject.Find(GameManager.shipType));
        Shoot();
    }

    public void RotateToAim(GameObject toTake)
    {
        //Vector3 takePos = toTake.transform.position;
        //Vector3 worldTakePos = Camera.main.ScreenToWorldPoint(takePos);
        Vector3 dir = toTake.transform.position - transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }

    public void Shoot()
    {
        if(canShoot)
        {
            canShoot = false;
            GameObject ammo_instantiated = Instantiate(ammo, aim.position, aim.rotation, projectilesSave);
            //ammo_instantiated.transform.rotation = aim.rotation;
            timing += Time.deltaTime;
        } else {
            timing += Time.deltaTime;
        }
        if(timing >= cadency)
        {
            canShoot = true;
            timing = 0;
        }
    }
}
