using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions_EnemyOVNI : MonoBehaviour
{
    //Barra de Vida
    [SerializeField] Transform lifeBar;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {

        if(other.name == "Ammo")
        {
            GetDamage(0.5f);
            Destroy(other);
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
