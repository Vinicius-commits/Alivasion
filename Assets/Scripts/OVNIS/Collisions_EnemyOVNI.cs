using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (CapsuleCollider))]
public class Collisions_EnemyOVNI : MonoBehaviour
{
    //Life Bar
    [SerializeField] Transform lifeBar;

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
            GetDamage(2.0f);
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
        lifeBar.localScale = new Vector3(1.0f, newLife, 1.0f);
        
        scorePlacar.GetScore(killValue);
    }
}
