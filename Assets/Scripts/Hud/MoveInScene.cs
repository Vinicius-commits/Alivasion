using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInScene : MonoBehaviour
{
    [SerializeField] float speedMoveScene;
    
    void Start()
    {
        speedMoveScene = -0.25f;
    }

    void Update()
    {
        Vector3 direction = Vector3.forward;
        transform.Translate(direction * speedMoveScene);
    }
}
