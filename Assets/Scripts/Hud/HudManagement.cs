using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManagement : MonoBehaviour
{

    [SerializeField] Text scorePlacar;
    int score;

    void Start()
    {
        score = 0;
        scorePlacar = GameObject.Find("ScorePlacar").GetComponent<Text>();
    }

    public void GetScore(int addScoreValue)
    {
        score += addScoreValue;
        scorePlacar.text = score.ToString();
         
    }
}
