using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun_TeleporterGun : MonoBehaviour
{
    [SerializeField] Transform player;

    public void AimGun()
    {
        player = GameObject.Find(GameManager.shipType).transform;

        Vector3 direction = player.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rot;
    }
}
