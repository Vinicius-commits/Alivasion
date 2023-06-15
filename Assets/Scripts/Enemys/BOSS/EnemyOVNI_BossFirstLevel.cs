using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOVNI_BossFirstLevel : MonoBehaviour
{
    [SerializeField] List<GameObject> lifeBars;
    [SerializeField] Transform lifebar;
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;
    
    private void Awake() {
        lifebar = GameObject.Find("BOSSLifeBar").transform;
        lifebar.GetChild(0).gameObject.SetActive(false);
    }
    void Start()
    {
        speed = 5.0f;
        direction = Vector3.forward;
        for(int i = 0; i < lifebar.GetChild(0).transform.childCount; i++)
        {
            lifeBars.Add(lifebar.GetChild(0).transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        
    }

    private void OnEnable() {
        lifebar.GetChild(0).gameObject.SetActive(true);
    }
    private void OnDisable() {
        lifebar.GetChild(0).gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other) {
        
    }

    private void OnDestroy() {
        
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
