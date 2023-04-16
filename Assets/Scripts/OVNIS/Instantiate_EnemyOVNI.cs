using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_EnemyOVNI : MonoBehaviour
{
    // This section controls what TYPE of enemy will be instatiate
    [SerializeField] List<GameObject> enemyTypes = new List<GameObject> ();
    [SerializeField] GameObject enemyToInstatiate;

    // This section controls the POSITION where the enemy will be instatiate
    [SerializeField] Vector3 positionRightLimit, positionLeftLimit, positionToInstantiate;


    //This section controls the TIME to instantiate the enemys 
    bool canInstantiate = true;
    float timeToInstantiate;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // SideInstantiate(gameObject, 1.0f, 1.5f, 1.0f, 1.5f);
        positionLeftLimit = GameObject.Find("MonitorLimitLeft").transform.position;
        positionRightLimit = GameObject.Find("MonitorLimitRight").transform.position;
        StartCoroutine(InstantiateControlTime());
    }

    public IEnumerator InstantiateControlTime()
    {
        if(canInstantiate)
        {
            canInstantiate = false;
            SideToInstantiate_Selection();
            yield return new WaitForSeconds(3.0f);
            canInstantiate = true;
        }
    }

    public void SideToInstantiate_Selection()
    {
        // This is a method to choose the side to instantiate the enemy
        int side;
        side = Random.Range(0, 4);

        switch(side)
        {
            case 0:
            //top
                EnemyBySideInstantiate(enemyToInstatiate, (positionLeftLimit.x - 2), (positionRightLimit.x + 2), positionRightLimit.z, (positionRightLimit.z + 2));
                break;
            case 1:
            //bottom
                EnemyBySideInstantiate(enemyToInstatiate, (positionLeftLimit.x - 2), (positionRightLimit.x + 2), (positionLeftLimit.z - 2), positionLeftLimit.z);
                break;
            case 2:
            //left
                EnemyBySideInstantiate(enemyToInstatiate, (positionLeftLimit.x - 2), positionLeftLimit.x, (positionLeftLimit.z - 2), (positionRightLimit.z + 2));
                break;
            case 3:
            //right
                EnemyBySideInstantiate(enemyToInstatiate, positionRightLimit.x, (positionRightLimit.x + 2), (positionLeftLimit.z - 2), (positionRightLimit.z + 2));
                break;
        }
    }

    public void EnemyType_Selection()
    {
        // This is a method to choose the type of enemy to instantiate

    }

    public void EnemyBySideInstantiate(GameObject enemyType, float xMin, float xMax, float zMin, float zMax)
    {
        // This is a generic method to instantiate the type of enemy at designed area (top, bottom, right or left) defined by a random system's choice
        float xPos, zPos;
        xPos = Random.Range(xMin, xMax);
        zPos = Random.Range(zMin, zMax);
        positionToInstantiate = new Vector3(xPos, 414, zPos);
        Instantiate(enemyType, positionToInstantiate, Quaternion.identity, transform);
    }
     
}

