using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (MeshCollider))]
public class Collisions_Ship : MonoBehaviour
{
    //Life Bar
    [SerializeField] Stack<GameObject> hearts = new Stack<GameObject>();

    void Start()
    {
        for(int heartCount = 0; GameObject.Find("Hearts").transform.childCount > heartCount; heartCount++)
        {
            hearts.Push(GameObject.Find("Hearts").transform.GetChild(heartCount).gameObject);
            Debug.Log(hearts.Peek());
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
