using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //Shooter
    [SerializeField] bool canCast;
    [SerializeField] GameObject ammo;
    [SerializeField] Transform aimTransform, shipTransform;
    [SerializeField] Vector3 locationToInstantiate = new Vector3(0, 413.0f, 0);
    Transform projectilesSave;
    
    void Start()
    {
        aimTransform = GameObject.Find("Aim").transform;
        shipTransform = GameObject.Find("PlayerShip").transform.GetChild(0).transform;
        projectilesSave = GameObject.Find("Projectiles").transform;
        canCast = true;
    }
    void FixedUpdate()
    {
        StartCoroutine(Shooting(ammo, aimTransform, shipTransform));
    }

    public IEnumerator Shooting(GameObject ammo, Transform aim, Transform ship)
    {
        if(canCast)
        {
            locationToInstantiate += aim.position;
            canCast = false;
            Instantiate(ammo, aim.position, ship.rotation, projectilesSave);
            //Instantiate(ammo, aim.position, aim.rotation);
            yield return new WaitForSeconds(0.5f);
            canCast = true;
        }
    }
}