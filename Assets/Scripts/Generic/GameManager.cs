using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Game Control
    public static GameManager instance;
    
    //ShipMontage
    public static string shipType = "PlayerShip_StrongShip";

    //fases to unlock
    static List<GameObject> fases = new List<GameObject>();
    static int fasesUnlocked = 0;
    [SerializeField] RectTransform fases_parent;

    //Volume Controller
    public static float musicTime;
    public static float volumeSFX; 
    public static float volumeMusic;
    [SerializeField] AudioSource backgroundSound;

    //Scene Detection
    static string currentScene;

    void Awake()
    {
        GMInstantiate();
    }

    private void FixedUpdate() {
        if(SceneChangeDetection())
        {
            CheckOutFases();
            ChangeShip(shipType);
        }
    }

    public void GMInstantiate()
    {
        if(instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void CheckOutFases()
    {
        if(SceneManager.GetActiveScene().name == "Garage")
        {
            fases_parent = GameObject.Find("Fases").GetComponent<RectTransform>(); 
            fases.Clear();
            for(int i = 0; i < fases_parent.childCount; i++)
            {
                fases.Add(fases_parent.GetChild(i).gameObject);
                if(i <= fasesUnlocked)
                {
                    fases[i].GetComponent<Button>().enabled = true;
                    fases[i].transform.GetChild(0).GetComponent<Text>().color = Color.white;
                }
            }
            
        }
    }

    public void ChangeMusicVolume(float value)
    {
        volumeMusic = value;
    }

    public void ChangeMusicVolume()
    {
        
    }

    public static void UnlockFase(int faseNumber)
    {
        faseNumber -= 1;
        fasesUnlocked = faseNumber;
    }



    public bool SceneChangeDetection()
    {
        bool changed = false;
        if(SceneManager.GetActiveScene().name != currentScene)
        {
            currentScene = SceneManager.GetActiveScene().name;
            changed = true;
        }
        return changed;
    }

    public bool SceneDetect(string sceneName)
    {
        bool verified = false;
        if(SceneManager.GetActiveScene().name == sceneName)
        {
            verified = true;
        }
        return verified;
    }

    public void ChangeShip(string shipType)
    {
        if(SceneDetect("Fase1") || SceneDetect("Fase2"))
        {
            Transform ships = GameObject.Find("Ships").transform;
            for(int i = 0; i < ships.childCount; i++)
            {
                if(ships.GetChild(i).gameObject.name == GameManager.shipType)
                {
                    ships.GetChild(i).gameObject.SetActive(true);
                } else {
                    ships.GetChild(i).gameObject.SetActive(false);
                }

            }
        }
    }
}
