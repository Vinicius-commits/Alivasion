using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    //Movement
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;

    //Shooter
    [SerializeField] bool canCast;
    [SerializeField] GameObject ammo;
    [SerializeField] Transform aim;

    //Life Bar
    [SerializeField] Stack<GameObject> hearts = new Stack<GameObject>();

    void Start()
    {
        speed = 25.0f;
        canCast = true;
        for(int heartCount = 0; GameObject.Find("Hearts").transform.childCount > heartCount; heartCount++)
        {
            hearts.Push(GameObject.Find("Hearts").transform.GetChild(heartCount).gameObject);
            Debug.Log(hearts.Peek());
        }
    }

    void FixedUpdate()
    {
        Movement(speed);
    }
    
    void Update()
    {
        StartCoroutine(Shooting(ammo, aim));
    }

    public void Movement(float speed)
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        transform.Translate(direction * speed * Time.deltaTime);
    }

    public IEnumerator Shooting(GameObject ammo, Transform aim)
    {
        if(canCast)
        {
            canCast = false;
            Instantiate(ammo, aim.position, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            canCast = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.parent.name == "Enemy(Clone)" || other.transform.parent.name == "Enemy")
        {
            GetDamage();
        }
    }

    public void GetDamage()
    {
        if(hearts.Count > 0)
        {
            Destroy(hearts.Pop());    
            Debug.Log(hearts.Count);
        } else
        {
            SceneChange.ChangeScene("GameOver");
        }
    }

    
}
