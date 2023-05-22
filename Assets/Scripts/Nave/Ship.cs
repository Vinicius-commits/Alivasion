using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] Ray ray;
    [SerializeField] RaycastHit hit;
    [SerializeField] Transform shipTransform, aimTransform;

    void Start() {
        speed = 100.0f;
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
        Vector3 cameraMin = Camera.main.ViewportToWorldPoint(new Vector3(0,0,transform.position.z));
        Vector3 cameraMax = Camera.main.ViewportToWorldPoint(new Vector3(1,1,transform.position.z));

        cameraMin.x += 0.5f * transform.localScale.x;
        cameraMin.y += 0.5f * transform.localScale.y;

        cameraMax.x += 0.5f * transform.localScale.x;
        cameraMax.y += 0.5f * transform.localScale.y;

        //this method is designed to control the ship movement with the WASD or the arrows
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //if((transform.position.x > cameraMin.x && direction.x < cameraMax.x) && (direction.z > cameraMin.y && direction.z < cameraMax.y))
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void ShipRotation()
    {
        //this method is designed to control the ship rotation with the mouse position
        
        /* Used references to make this method: 
        Marcos Schultz - video Youtube ensinando mecanicas da unity - 
        https://www.youtube.com/watch?v=6nzWIsztYBE

        SatellaSoft - video Youtube ensinando mecanicas da unity - 
        https://www.youtube.com/watch?v=WlpmyDArV7Q
        */

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