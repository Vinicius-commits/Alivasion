using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions_EnemyOVNI : MonoBehaviour
{
    //Life Bar
    [SerializeField] Transform lifeBar;
    [SerializeField] float newLife;
    [SerializeField] bool hasDestroyedByPlayer = false;

    //Score
    [SerializeField] HudManagement scorePlacar;
    [SerializeField] int killValue;


    private void Start() {
        scorePlacar = GameObject.Find("Hud").GetComponent<HudManagement>();    
    }
    private void OnTriggerEnter(Collider other) {

        if(other.name == "Ammo")
        {
            Destroy(other.gameObject);
            GetDamage(ShipAmmunition_Action.damage);
            if(lifeBar.localScale.y <= 0)
            {
                if(newLife <= 0)
                    hasDestroyedByPlayer = true;
                Destroy(transform.parent.gameObject);
            }
        }
    }

    private void OnDestroy() {
        if(hasDestroyedByPlayer)
            scorePlacar.GetScore(killValue);
    }
    
    public void GetDamage(float damage)
    {
        newLife = lifeBar.localScale.y;
        newLife -= damage;
        lifeBar.localScale = new Vector3(1.0f, newLife, 1.0f);
    }
}
