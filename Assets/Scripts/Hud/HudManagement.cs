using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManagement : MonoBehaviour
{

    [SerializeField] Text limScore;
    [SerializeField] GameObject scorePlacar, bossGO;
    int score;

    private void Awake() {
        bossGO = GameObject.Find("BOSS");
    }
    void Start()
    {
        score = 0;
        scorePlacar = GameObject.Find("ScorePlacar");
        limScore = scorePlacar.transform.GetChild(0).GetComponent<Text>();
        bossGO.SetActive(false);
    }

    public void GetScore(int addScoreValue)
    {
        score += addScoreValue;
        scorePlacar.GetComponent<Text>().text = score.ToString();
        int limScoreNum = Convert.ToInt32(limScore.text);
        if (score >= limScoreNum)
        {  
            bossGO.SetActive(true);
            //GameObject.Find("BOSS").SetActive(true);
            //SceneChange.ChangeScene("GameWon");
        }
         
    }
}
