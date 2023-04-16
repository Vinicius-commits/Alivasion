using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Ship : MonoBehaviour
{
    //Shooter
    [SerializeField] bool canCast;
    [SerializeField] GameObject ammo;
    [SerializeField] Transform aimTransform, shipTransform;
    
    void Start()
    {
        canCast = true;
    }
    void Update()
    {
        StartCoroutine(Shooting(ammo, aimTransform, shipTransform));
    }

    public IEnumerator Shooting(GameObject ammo, Transform aim, Transform ship)
    {
        if(canCast)
        {
            canCast = false;
            Instantiate(ammo, aim.position, ship.rotation, aim);
            //Instantiate(ammo, aim.position, aim.rotation);
            yield return new WaitForSeconds(0.5f);
            canCast = true;
        }
    }
}