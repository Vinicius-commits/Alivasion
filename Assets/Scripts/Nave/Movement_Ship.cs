using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Ship : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed, rotSpeed;
    [SerializeField] Ray ray;
    [SerializeField] RaycastHit hit;
    [SerializeField] Transform shipTransform, aimTransform;

    void Start() {
        speed = 100.0f;
        rotSpeed = 5.0f;
        shipTransform = transform.GetChild(0);
    }

    void Update()
    {
        ShipRotation();
    }
    void FixedUpdate()
    {
        Movement(speed);
    }

    public void Movement(float speed)
    {
        //this method is designed to control the ship movement with the WASD or the arrows
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void ShipRotation()
    {
        //this method is designed to control the ship rotation with the mouse position
        if(!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            return;
        
        Vector3 mouseLookDirection = hit.point - shipTransform.transform.position;
        mouseLookDirection.y = 0;
        // Debug.Log($"{mouseLookDirection} = mouse look direction");
        // Debug.Log($"{hit.point} = hit.point");

        Quaternion rot = Quaternion.LookRotation(mouseLookDirection);
        shipTransform.GetComponent<Rigidbody>().MoveRotation(rot);
        //ship.transform.rotation = Quaternion.Lerp(ship.transform.rotation, rot, rotSpeed * Time.deltaTime);

        //aim's rotation
        aimTransform = shipTransform.GetChild(0);
        aimTransform.rotation = shipTransform.rotation;
    }

}