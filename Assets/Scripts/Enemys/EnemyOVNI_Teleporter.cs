using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOVNI_Teleporter : MonoBehaviour
{
    [SerializeField] List<GameObject> positions;
    [SerializeField] bool canTeleport;
    [SerializeField] int positionToTeleport;
    [SerializeField] float timing_Teleport = 0;

    void Start()
    {
        for(int i = 0; i < GameObject.Find("PrePositions").transform.childCount; i++)
        {
            positions.Add(GameObject.Find("PrePositions").transform.GetChild(i).gameObject);
        }
    }

    void FixedUpdate()
    {    
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        Teleport();
        Attack();
    }

    public void Attack()
    {
        //Instantiate(ammunition, aim, gunTransform);
        
        
    }

    public void Teleport()
    {
        if(canTeleport && timing_Teleport >= 5.0f && LevelManagement.canMove == true)
        {
            positionToTeleport = Random.Range(0, positions.Count);

            for(float cont = 0; cont > 0.1f; cont -= 0.2f)
            {
                transform.localScale -= transform.localScale / 10.0f;
                // while(timing > 0)
                // {
                //     timing -= Time.deltaTime;
                //     Debug.Log(timing + "timer 1");
                // }
                for(float c = 0; c <= 10.0f; c += Time.deltaTime)
                {
                    Debug.Log("timer 1");
                    
                }
            }

            transform.position = positions[positionToTeleport].transform.position;

            for(float cont = 0; cont > 0.1f; cont -= 0.2f)
            {
                transform.localScale -= transform.localScale / 10.0f;
                // while(timing > 0)
                // {
                //     timing -= Time.deltaTime;
                //     Debug.Log(timing + "timer 1");
                // }
                for(float c = 0; c <= 10.0f; c += Time.deltaTime)
                {
                    Debug.Log("timer 1");
                    
                }
            }
            canTeleport = true;
            timing_Teleport = 0;
        }
        timing_Teleport += Time.deltaTime;
    }

    public void Timer(bool canCounting)
    {
        float timing = 0;
        if(canCounting)
        {
            timing += Time.deltaTime;
            for(float c = 0; c <= 10.0f; c += Time.deltaTime)
            {
                Debug.Log("timer 1");
                
            }
        }
    }
}
