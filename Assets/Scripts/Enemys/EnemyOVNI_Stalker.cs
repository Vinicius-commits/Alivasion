using UnityEngine;

public class EnemyOVNI_Stalker : MonoBehaviour
{
    //Movement
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    void Start()
    {
        speed = 50.0f;
        direction = Vector3.forward;
    }

    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        if(LevelManagement.canMove)
        {
            //direction = Vector3.forward;
            transform.LookAt(GameObject.Find(GameObject.Find("GameManager").GetComponent<GameManager>().shipType).transform.position);
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
