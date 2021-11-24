using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HighScoreController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI HighScore1;
    public TMPro.TextMeshProUGUI HighScore2;
    public TMPro.TextMeshProUGUI HighScore3;
    public TMPro.TextMeshProUGUI HighScore4;
    public TMPro.TextMeshProUGUI HighScore5;
    public TMPro.TextMeshProUGUI HighScore6;
    public TMPro.TextMeshProUGUI HighScore7;
    public TMPro.TextMeshProUGUI HighScore8;
    public TMPro.TextMeshProUGUI HighScore9;

  
    private void Awake()
    {
        HighScore1.text = TimeCalc(PlayerPrefs.GetFloat("LevelHighScore1"));
        HighScore2.text = TimeCalc(PlayerPrefs.GetFloat("LevelHighScore2"));
        HighScore3.text = TimeCalc(PlayerPrefs.GetFloat("LevelHighScore3"));
        HighScore4.text = TimeCalc(PlayerPrefs.GetFloat("LevelHighScore4"));
        HighScore5.text = TimeCalc(PlayerPrefs.GetFloat("LevelHighScore5"));
        HighScore6.text = TimeCalc(PlayerPrefs.GetFloat("LevelHighScore6"));
        //HighScore7.text = TimeCalc(PlayerPrefs.GetFloat("LevelHighScore7"));
        //HighScore8.text = TimeCalc(PlayerPrefs.GetFloat("LevelHighScore8"));
        //HighScore9.text = TimeCalc(PlayerPrefs.GetFloat("LevelHighScore9"));
    }

    private string TimeCalc(float total)
    {

        float min = Mathf.Floor(total / 60f % 60f);
        float sec = Mathf.Floor(total % 60f);
        float msec = (float)Math.Round((double)Mathf.Floor((total - sec) * 100f), 2);
        string msecString = msec.ToString("00");
        if (msecString.Length > 2)
            msecString = msecString.Remove(2);

        return "Highscore: " + string.Format("{0}:{1}:{2}", min.ToString("00"), sec.ToString("00"), msecString);
    }


}
