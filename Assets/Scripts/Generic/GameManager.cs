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
        // backgroundSound = Camera.main.GetComponent<AudioSource>();

        // backgroundSound.volume = volumeMusic;

        // try{
        //     // if(volumeMusic != GameObject.Find("VolumeConfig").GetComponent<Slider>().value)
        //     //     GameObject.Find("VolumeConfig").GetComponent<Slider>().value = volumeMusic;
        // } catch {
        //     Debug.Log("No founded slider");
        // }

        if(SceneDetection())
        {
            CheckOutFases();
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

    public bool SceneDetection()
    {
        bool changed = false;
        if(SceneManager.GetActiveScene().name != currentScene)
        {
            currentScene = SceneManager.GetActiveScene().name;
            changed = true;
        }
        return changed;
    }
}
