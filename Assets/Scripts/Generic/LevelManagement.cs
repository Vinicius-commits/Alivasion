using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
    public KeyCode tec;
    public bool infiniteLife = false;

    public void FixedUpdate()
    {
        if(Input.GetKey(tec))
        {
            switch(tec)
            {
                case KeyCode.Escape:
                    if(SceneManager.sceneCount < 2)
                    {
                        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
                    }
                    else{
                        SceneManager.UnloadSceneAsync("Pause");
                    }
                    break;
                case KeyCode.F2:
                    SceneManager.LoadScene("Fase2");
                    break;
                case KeyCode.F3:
                    //InfiniteLife
                    infiniteLife = !infiniteLife;
                    break;
            }
        }
    }

    public void CloseButton()
    {
        SceneManager.UnloadSceneAsync("Pause");
    }
}
