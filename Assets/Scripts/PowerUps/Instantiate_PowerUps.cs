using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_PowerUps : MonoBehaviour
{
    [SerializeField] List<GameObject> powerUps_Types = new List<GameObject>();
    [SerializeField] GameObject powerUp_Selected;
    [SerializeField] int randomChoice, chanceToInstantiate;

    void Start()
    {
        chanceToInstantiate = Random.Range(0, 100);
        if(chanceToInstantiate <= 10)
        {
            randomChoice = Random.Range(0, powerUps_Types.Count);
            powerUp_Selected = powerUps_Types[randomChoice];
        }
    }

    private void OnDestroy() {
        if(chanceToInstantiate <= 30)
        {
            randomChoice = Random.Range(0, powerUps_Types.Count);
            powerUp_Selected = powerUps_Types[randomChoice];
            Instantiate(powerUp_Selected, transform.position, Quaternion.identity, transform.parent);
        }
    }
}
