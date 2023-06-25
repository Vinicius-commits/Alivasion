using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOVNI_BossSecondLevel : MonoBehaviour
{
    [SerializeField] List<GameObject> lifeBars;
    [SerializeField] Transform lifebar;
    [SerializeField] float speed;
    [SerializeField] Vector3 direction, callBossPosition;
    [SerializeField] bool inAttack = false, canAttack = false;
    
    private void Awake() {
        //Catch LifeBar_Background
        callBossPosition = new Vector3(0,0,20.0f);
        lifebar = GameObject.Find("BOSSLifeBar").transform.GetChild(0);
        lifebar.gameObject.SetActive(false);
    }
    void Start()
    {
        speed = 2.0f;
        direction = Vector3.forward;
        for(int i = 0; i < lifebar.GetChild(0).transform.childCount; i++)
        {
            lifeBars.Add(lifebar.GetChild(0).transform.GetChild(i).gameObject);
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void OnEnable() {
        lifebar.gameObject.SetActive(true);
    }
    private void OnDisable() {
        lifebar.gameObject.SetActive(false);
    }

    public void InitialMovement()
    {
        if(transform.parent.localPosition.z < 2119.0f && !inAttack)
        {
            callBossPosition.z = 0.5f;
            transform.parent.transform.localPosition += callBossPosition * speed;
        } else if(transform.parent.localPosition.z >= 2119.0f && !inAttack)
        {
            canAttack = true;
        }
    }

    public void Movement()
    {
        InitialMovement();
        Attack();
        FinalMovement();
    }

    public void FinalMovement()
    {
        if(transform.parent.localPosition.z > 1996.0f && !inAttack)
        {
            callBossPosition.z = -0.5f;
            transform.parent.transform.localPosition += callBossPosition * speed;
        }
    }

    public void Attack()
    {
        if(!inAttack && canAttack)
        {    
            inAttack = true;
            
        }
    }

    public bool GenericTimer(float interval)
    {
        float timing = 0;
        while(true)
        {
            timing += Time.deltaTime;
            if(timing >= interval)
            {
                break;
            }
        }
        return true;
    }

    public void GetDamage()
    {
        if(lifeBars.Count >= 1)
        {
            RectTransform life;
            if(lifeBars.Count >= 2)
            {
                life = lifeBars[1].GetComponent<RectTransform>();
                life.localScale = new Vector3(life.localScale.x - 0.01f, life.localScale.y, life.localScale.z);
                if(life.localScale.x <= 0)
                {
                    Destroy(lifeBars[1].gameObject);
                    lifeBars.RemoveAt(1);
                }
            } else if(lifeBars.Count == 1) {
                life = lifeBars[0].GetComponent<RectTransform>();
                life.localScale = new Vector3(life.localScale.x - 0.01f, life.localScale.y, life.localScale.z);
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
