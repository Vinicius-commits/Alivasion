using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_EnemyOVNI : MonoBehaviour
{
    // This section controls what TYPE of enemy will be instatiate
    [SerializeField] List<GameObject> enemyTypes = new List<GameObject> ();
    [SerializeField] GameObject enemyToInstatiate;

    // This section controls the POSITION where the enemy will be instatiate
    Vector3 PositionToInstantiate;

    //This section controls the TIME to instantiate the enemys 
    bool canInstantiate = true;
    float timeToInstantiate;


    void Start()
    {

    }

    void FixedUpdate()
    {
        // SideInstantiate(gameObject, 1.0f, 1.5f, 1.0f, 1.5f);
        StartCoroutine(InstantiateControlTime());
    }

    public IEnumerator InstantiateControlTime()
    {
        if(canInstantiate)
        {
            canInstantiate = false;
            SideToInstantiate_Selection();
            yield return new WaitForSeconds(2.0f);
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
                EnemyBySideInstantiate(enemyToInstatiate, -28.0f, 28.0f, 15.0f, 17.0f);
                break;
            case 1:
            //bottom
                EnemyBySideInstantiate(enemyToInstatiate, -28.0f, 28.0f, -17.0f, -15.0f);
                break;
            case 2:
            //left
                EnemyBySideInstantiate(enemyToInstatiate, -28.0f, -26.0f, -17.0f, 17.0f);
                break;
            case 3:
            //right
                EnemyBySideInstantiate(enemyToInstatiate, 26.0f, 28.0f, -17.0f, 17.0f);
                break;
        }
    }

    public void EnemyType_Selection()
    {
        // This is a method to choose the type of enemy to instantiate

    }

    public void EnemyBySideInstantiate(GameObject enemyType, float xMin, float xMax, float yMin, float yMax)
    {
        // This is a generic method to instantiate the type of enemy at designed area (top, bottom, right or left) defined by a random system's choice
        float xPos, yPos;
        xPos = Random.Range(xMin, xMax);
        yPos = Random.Range(yMin, yMax);
        Vector3 positionToInstantiate;
        positionToInstantiate = new Vector3(xPos, yPos, 23.0f);
        Instantiate(enemyType, positionToInstantiate, Quaternion.identity, transform);
    }
     
}

