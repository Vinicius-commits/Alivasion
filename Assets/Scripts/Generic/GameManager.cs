using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
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
            GameObject.Find("VolumeConfig").GetComponent<Slider>().value = volumeMusic;
        } catch {
            Debug.Log("No founded slider");
        }
    }

    void GMInstantiate()
    {
        if(instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        Debug.Log("gameManager");
    }

    public void ChangeVolume(float value)
    {
        volumeMusic = value;
    }
}
