using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste2 : MonoBehaviour
{
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.down * 0.2f);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger2");
    }

    // private void OnCollisionEnter(Collision other) {
    //     Debug.Log("Collision2");
    // }
}
