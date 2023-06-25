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
    [SerializeField] float distanceInterLifePoints;

    //Audio Control
    [SerializeField] AudioSource audioManager_Ship;

    //Getting damage
    [SerializeField] AudioClip gettingDamage_audio;
    [SerializeField] bool canGetDamage = true;

    //Getting PwrUp
    public Stack<GameObject> pwrUps = new Stack<GameObject>();
    [SerializeField] AudioClip pickUpPwr_audio;
    //[SerializeField] List<GameObject[]> shields = new List<GameObject[]>();
    [SerializeField] GameObject pwrUp_Slots, shield;
    [SerializeField] float distanceInterPwrUpSlots;

    void Start()
    {
        audioManager_Ship = gameObject.GetComponent<AudioSource>();
        hearts_Slots = GameObject.Find("Hearts");
        for(int heartCount = 0; hearts_Slots.transform.childCount > heartCount; heartCount++)
        {
            hearts.Push(hearts_Slots.transform.GetChild(heartCount).gameObject);
        }

        pwrUp_Slots = GameObject.Find("PowerUps");
        for(int pwrCount = 0; pwrUp_Slots.transform.childCount > pwrCount; pwrCount++)
        {
            pwrUps.Push(pwrUp_Slots.transform.GetChild(pwrCount).gameObject);
        }
        distanceInterLifePoints = Vector3.Distance(hearts_Slots.transform.GetChild(0).transform.position, hearts_Slots.transform.GetChild(1).transform.position);        
        distanceInterPwrUpSlots = Vector3.Distance(pwrUp_Slots.transform.GetChild(0).transform.position, pwrUp_Slots.transform.GetChild(1).transform.position);
        //shields.Add(GameObject.FindGameObjectsWithTag("Shield"));
        shield = transform.parent.GetChild(1).gameObject;
        // for(int i = 0; i < shields.Count; i++)
        // {
        //     Debug.Log(shields[0][i].name);
        //     shields[0][i].SetActive(false);
        // }
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
            Shooter.shotRange += 0.1f;
            Destroy(other.gameObject);
        } else if(other.name == "ShieldPwrUp(Clone)")
        {
            GetPwrUp();
            GetShield();
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

    public void GetShield()
    {
        
    }

    public void UseShield()
    {
        
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
