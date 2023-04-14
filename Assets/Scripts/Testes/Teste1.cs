using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Transform visao = transform;
        visao.LookAt(GameObject.Find("Cube2").transform.position);
    }

    
}
