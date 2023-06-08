using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_PowerUps : MonoBehaviour
{
    [SerializeField] List<GameObject> powerUps_Types = new List<GameObject>();
    [SerializeField] GameObject powerUp_Selected;
    [SerializeField] int randomChoice_PwrUpType, chanceToInstantiate_PwrUpType;

    void Start()
    {
        chanceToInstantiate_PwrUpType = Random.Range(0, 100);
        if(chanceToInstantiate_PwrUpType <= 10)
        {
            randomChoice_PwrUpType = Random.Range(0, powerUps_Types.Count);
            powerUp_Selected = powerUps_Types[randomChoice_PwrUpType];
        }
    }

    private void OnDestroy() {
        if(chanceToInstantiate_PwrUpType <= 30)
        {
            randomChoice_PwrUpType = Random.Range(0, powerUps_Types.Count);
            powerUp_Selected = powerUps_Types[randomChoice_PwrUpType];
            Instantiate(powerUp_Selected, transform.position, Quaternion.identity, transform.parent);
        }
    }
}
