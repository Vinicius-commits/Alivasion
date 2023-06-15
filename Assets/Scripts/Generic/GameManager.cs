using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public static string shipType = "PlayerShip_StrongShip";
    [SerializeField] GameObject fases;
    [SerializeField] List<bool> unlockedFases, lockedFases;
    [SerializeField] GameObject shipGameObject;

    public float volumeSFX, volumeMusic;
   
    [SerializeField] AudioSource backgroundSound;


    void Awake()
    {
        GMInstantiate();
    }

    private void FixedUpdate() {
        backgroundSound = Camera.main.GetComponent<AudioSource>();

        backgroundSound.volume = volumeMusic;

        try{
            // if(volumeMusic != GameObject.Find("VolumeConfig").GetComponent<Slider>().value)
            //     GameObject.Find("VolumeConfig").GetComponent<Slider>().value = volumeMusic;
        } catch {
            Debug.Log("No founded slider");
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
}
