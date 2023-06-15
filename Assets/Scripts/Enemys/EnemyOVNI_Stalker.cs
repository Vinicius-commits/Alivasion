using UnityEngine;

public class EnemyOVNI_Stalker : MonoBehaviour
{
    //Movement
    [SerializeField] float speed, timer = 0;
    [SerializeField] Vector3 direction;
    [SerializeField] bool inAttack = false;
    [SerializeField] GameObject ship;

    void Start()
    {
        ship = GameObject.Find(GameManager.shipType);
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
            transform.LookAt(ship.transform.position);
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void Attack()
    {
        float shipDistance = Vector3.Distance(ship.transform.position, transform.position);
        if(shipDistance <= 45.0f)
        {
            inAttack = true;
        }

        if(inAttack)
        {
            timer += Time.deltaTime;

            if(timer >=0.89f && LevelManagement.infiniteLife == false && shipDistance <= 50.0f)    
            {
                //VFXExplosion
                ship.transform.GetChild(0).GetComponent<Collisions_Ship>().GetDamage();
                Destroy(gameObject);
            } else {
                //VFXExplosion
                Destroy(gameObject);
            }
        }
    }
}
