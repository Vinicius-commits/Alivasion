using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions_Boss : MonoBehaviour
{
    [SerializeField] GameObject bossGO;
    
    void Start()
    {
        bossGO = GameObject.Find("BOSS").transform.GetChild(0).gameObject;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.parent.name == "Ammunition(Clone)")
        {
            bossGO.GetComponent<EnemyOVNI_BossFirstLevel>().GetDamage();
        }
    }
}
