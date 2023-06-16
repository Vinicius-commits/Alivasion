using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public static string shipType = "PlayerShip_StrongShip";
    [SerializeField] GameObject shipGameObject;

    //fases to unlock
    static List<GameObject> fases = new List<GameObject>();
    static int fasesUnlocked = 0;
    [SerializeField] RectTransform fases_parent;
    public static float volumeSFX; 
    public static float volumeMusic;
   
    [SerializeField] AudioSource backgroundSound;


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

    public void ChangeVolume(float value)
    {
        volumeMusic = value;
    }

    public static void UnlockFase(int faseNumber)
    {
        faseNumber -= 1;
        fasesUnlocked = faseNumber;
    }
}
