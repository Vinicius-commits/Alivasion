using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOVNI_BossFirstLevel : MonoBehaviour
{
    [SerializeField] List<GameObject> lifeBars;
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;
    void Start()
    {
        speed = 5.0f;
        direction = Vector3.forward;
        for(int i = 0; i < GameObject.Find("BOSSLifeBar_Background").transform.childCount; i++)
        {
            lifeBars.Add(GameObject.Find("BOSSLifeBar_Background").transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        
    }

    public void Movement()
    {
        
        transform.position = new Vector3(0,0,0);
    }

    public void Attack()
    {

    }

    public void GetDamage()
    {
        GameObject.Find("LifeBar2").transform.localScale.Set(GameObject.Find("LifeBar2").transform.localScale.x - 0.2f, GameObject.Find("LifeBar2").transform.localScale.y, GameObject.Find("LifeBar2").transform.localScale.z);
    }
}
