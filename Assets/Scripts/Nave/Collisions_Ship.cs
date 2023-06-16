using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof (AudioSource))]

public class Collisions_Ship : MonoBehaviour
{
    //Life Bar
    public Stack<GameObject> hearts = new Stack<GameObject>();
    
    [SerializeField] GameObject life_Slot, hearts_Slots;

    [SerializeField] AudioClip gettingDamage_audio, pickUpPwr_audio;
    [SerializeField] AudioSource audioManager_Ship;
    [SerializeField] bool canGetDamage = true;
    [SerializeField] float distanceInterLifePoints;
    void Start()
    {
        audioManager_Ship = gameObject.GetComponent<AudioSource>();
        hearts_Slots = GameObject.Find("Hearts");
        for(int heartCount = 0; hearts_Slots.transform.childCount > heartCount; heartCount++)
        {
            hearts.Push(hearts_Slots.transform.GetChild(heartCount).gameObject);
        }
        distanceInterLifePoints = Vector3.Distance(hearts_Slots.transform.GetChild(0).transform.position, hearts_Slots.transform.GetChild(1).transform.position);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.parent.tag == "Enemy" && LevelManagement.infiniteLife == false || LevelManagement.infiniteLife == false && other.tag == "Enemy")
        {
            GetDamage();
        } else if(other.name == "EnergyPwrUp(Clone)")
        {
            GetPwrUp();
            GetHeal();
            Destroy(other.gameObject);
        } else if(other.name == "AmmoPwrUp(Clone)")
        {
            GetPwrUp();
            Destroy(other.gameObject);
        } else if(other.name == "ShieldPwrUp(Clone)")
        {
            GetPwrUp();
            Destroy(other.gameObject);
        }
        
    }

    public void GetPwrUp()
    {
        audioManager_Ship.clip = pickUpPwr_audio;
        audioManager_Ship.Play();
    }

    public void GetHeal()
    {
        Vector3 positionToInstantiate = new Vector3((4 * distanceInterLifePoints),0,0) + hearts.Peek().transform.localPosition;
        Instantiate(life_Slot, hearts_Slots.transform);
        hearts.Push(hearts_Slots.transform.GetChild(hearts_Slots.transform.childCount - 1).gameObject);
        hearts.Peek().transform.localPosition = positionToInstantiate;
    }

    public void GetDamage()
    {
        if(hearts.Count > 1 && canGetDamage == true)
        {
            canGetDamage = false;
            audioManager_Ship.clip = gettingDamage_audio;
            audioManager_Ship.Play();
            Destroy(hearts.Pop());
            for(float cont = 0; cont <= 2.0f; cont += Time.deltaTime)
            {
                Debug.Log("timer");
            }
            canGetDamage = true;
        
        } else
        {
            SceneChange.ChangeScene("GameOver");
        }
    }
}
