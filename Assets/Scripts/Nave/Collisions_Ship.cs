using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof (MeshCollider))]
public class Collisions_Ship : MonoBehaviour
{
    //Life Bar
    [SerializeField] Stack<GameObject> hearts = new Stack<GameObject>();
    [SerializeField] GameObject life_Slot, hearts_Slots;

    void Start()
    {
        hearts_Slots = GameObject.Find("Hearts");
        for(int heartCount = 0; hearts_Slots.transform.childCount > heartCount; heartCount++)
        {
            hearts.Push(hearts_Slots.transform.GetChild(heartCount).gameObject);
            Debug.Log(hearts.Peek());
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.parent.name == "Enemy(Clone)" || other.transform.parent.name == "Enemy")
        {
            GetDamage();
        } else if(other.name == "EnergyPwrUp(Clone)")
        {
            GetHeal();
            Destroy(other.gameObject);
        } else if(other.name == "BulletPwrUp(Clone)")
        {
            
            Destroy(other.gameObject);
        }
    }

    private void Update() {
        Debug.Log(hearts.Peek().transform.localPosition);
    }
    public void GetHeal()
    {
        Vector3 positionToInstantiate = new Vector3(4.0f,0,0) + hearts.Peek().transform.localPosition;
        Instantiate(life_Slot, hearts_Slots.transform);
        hearts.Push(hearts_Slots.transform.GetChild(hearts_Slots.transform.childCount - 1).gameObject);
        hearts.Peek().transform.localPosition = positionToInstantiate;
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
