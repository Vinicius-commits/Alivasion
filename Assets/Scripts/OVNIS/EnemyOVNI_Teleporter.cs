using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOVNI_Teleporter : MonoBehaviour
{
    [SerializeField] List<GameObject> positions;
    [SerializeField] bool canTeleport;

    float timing = 0;
    void Start()
    {
        positions.Add(GameObject.Find("TeleporterPosition_1"));
        positions.Add(GameObject.Find("TeleporterPosition_2"));
        positions.Add(GameObject.Find("TeleporterPosition_3"));
        positions.Add(GameObject.Find("TeleporterPosition_4"));
    }

    void Update()
    {
        Teleport();
        Attack();
    }

    public void Teleport()
    {
        if(canTeleport)
        {
            canTeleport = false;
            int positionToTeleport;
            positionToTeleport = Random.Range(0, positions.Count);
            // for(float cont = 0; cont > 0.1f; cont -= 0.2f)
            // {
            //     transform.localScale -= transform.localScale / 10.0f;
            // }
            transform.position = positions[positionToTeleport].transform.position;
        }

        while(timing < 6.0f)
        {
            timing += Time.deltaTime;
        }

        canTeleport = true;
    }    

    public void Attack()
    {
        //Instantiate(ammunition, aim, gunTransform);   
    }
}
