using UnityEngine;

public class EnemyOVNI_Stalker : MonoBehaviour
{
    //Movement
    [SerializeField] float speed, timer = 0;
    [SerializeField] Vector3 direction;
    [SerializeField] bool inAttack = false;

    void Start()
    {
        speed = 55.0f;
        direction = Vector3.forward;
    }

    void FixedUpdate()
    {
        if(!inAttack)
        {
            Movement();
        }
        Attack();
    }

    void Movement()
    {
        if(LevelManagement.canMove)
        {
            //direction = Vector3.forward;
            transform.LookAt(GameObject.Find(GameManager.shipType).transform.position);
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void Attack()
    {
        float shipDistance = Vector3.Distance(GameObject.Find(GameManager.shipType).transform.position, transform.position);
        if(shipDistance <= 50.0f)
        {
            inAttack = true;
                        
            //Explosion Animation
            //Timer To Explosion
            timer += Time.deltaTime;
            if(timer >=3.0f)    
                Destroy(gameObject);
        }

        if(inAttack)
        {
            timer += Time.deltaTime;
            if(timer >=0.89f)    
                Destroy(gameObject);
        }
    }
}
