using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMontage : MonoBehaviour
{
    public List<GameObject> ships;
    [SerializeField] List<Texture2D> textures;

    void Start()
    {
        for(int cont = 0; cont < transform.childCount; cont++)
        {
            ships.Add(transform.GetChild(cont).gameObject);
        }
    }

    public void ShipChange(int shipIndex)
    {
        ships[shipIndex].gameObject.GetComponent<MeshRenderer>().enabled = true;
        
        for(int cont = 0; cont < transform.childCount; cont++)
        {
            if(cont != shipIndex)
            {
                ships[cont].gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
