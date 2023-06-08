using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof (AudioSource))]
public class Shooter : MonoBehaviour
{
    //Shooter
    [SerializeField] bool canCast;
    [SerializeField] GameObject ammo;
    [SerializeField] Transform aimTransform, shipTransform, projectilesSave;
    [SerializeField] Vector3 locationToInstantiate = new Vector3(0, 413.0f, 0);

    [SerializeField] AudioSource audioManager_Shooter;
    [SerializeField] AudioClip audio_ShootingShip;
    
    void Start()
    {
        audioManager_Shooter = transform.parent.transform.parent.GetComponent<AudioSource>();
        aimTransform = transform.GetChild(0); //mudar para o aim do objeto/ canhao
        shipTransform = GameObject.Find(GameManager.shipType).transform.GetChild(0).transform;
        projectilesSave = GameObject.Find("Projectiles").transform;
        canCast = true;
    }
    void FixedUpdate()
    {
        StartCoroutine(Shooting(ammo, aimTransform, shipTransform));
    }

    public IEnumerator Shooting(GameObject ammo, Transform aim, Transform ship)
    {
        if(canCast && LevelManagement.canMove)
        {
            locationToInstantiate += aim.position;
            canCast = false;
            audioManager_Shooter.clip = audio_ShootingShip;
            audioManager_Shooter.Play();
            Instantiate(ammo, aim.position, ship.rotation, projectilesSave);
            //Instantiate(ammo, aim.position, aim.rotation);
            yield return new WaitForSeconds(0.5f);
            canCast = true;
        }
    }
}