using UnityEngine;

public class Movement_EnemyOVNI : MonoBehaviour
{
    //Movement
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    void Start()
    {
        speed = 30.0f;
        direction = new Vector3();
    }

    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        direction = Vector3.forward;
        transform.LookAt(GameObject.Find("PlayerShip").transform.position);
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
