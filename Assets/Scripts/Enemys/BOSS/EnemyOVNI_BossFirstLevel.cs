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
        //Catch LifeBar_Background
        lifebar = GameObject.Find("BOSSLifeBar").transform.GetChild(0);
        lifebar.gameObject.SetActive(false);
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
        lifebar.gameObject.SetActive(true);
    }
    private void OnDisable() {
        lifebar.gameObject.SetActive(false);
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
        if(lifeBars.Count >= 1)
        {
            RectTransform life;
            if(lifeBars.Count >= 2)
            {
                life = lifeBars[1].GetComponent<RectTransform>();
                life.localScale = new Vector3(life.localScale.x - 0.02f, life.localScale.y, life.localScale.z);
                if(life.localScale.x <= 0)
                {
                    Destroy(lifeBars[1].gameObject);
                    lifeBars.RemoveAt(1);
                }
            } else if(lifeBars.Count == 1) {
                life = lifeBars[0].GetComponent<RectTransform>();
                life.localScale = new Vector3(life.localScale.x - 0.02f, life.localScale.y, life.localScale.z);
                if(life.localScale.x <= 0)    
                {
                    Destroy(lifeBars[0].gameObject);
                    lifeBars.RemoveAt(0);
                }    
            }
        } else {
            SceneChange.ChangeScene("GameWon");
            GameManager.UnlockFase(2);
            Destroy(lifebar.gameObject);
            Destroy(gameObject);
        }
    }
}
