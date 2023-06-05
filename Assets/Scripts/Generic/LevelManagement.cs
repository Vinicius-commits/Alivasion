using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static bool infiniteLife, canMove;

    private void Start() {
        canMove = true;
        pauseMenu = transform.GetChild(0).transform.GetChild(0).gameObject;
        pauseMenu.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene("Fase2");
        } 

        else if (Input.GetKeyDown(KeyCode.F3))
        {
            infiniteLife = !infiniteLife;
        } 
        
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            canMove = !canMove;
        }

    }

    public void CloseButton()
    {
        SceneManager.UnloadSceneAsync("Pause");
    }
}
