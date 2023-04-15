using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (CapsuleCollider))]
public class Collisions_EnemyOVNI : MonoBehaviour
{
    //Barra de Vida
    [SerializeField] Transform lifeBar;

    private void OnTriggerEnter(Collider other) {

        if(other.name == "Ammo")
        {
            Destroy(other.gameObject);
            GetDamage(0.5f);
            if(lifeBar.localScale.y <= 0)
            {
                Destroy(gameObject);
                Destroy(lifeBar.gameObject);
            }
        }
    }

    public void GetDamage(float damage)
    {
        float newLife = lifeBar.localScale.y;
        newLife -= damage;
        lifeBar.localScale = new Vector3(0.2f, newLife, 0.2f);
    }
}
