using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class StopWatchController : MonoBehaviour
{

    public Text currentScoreText;
    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
       
        highScoreText.text = TimeCalc();
    }

    // Update is called once per frame
    void Update()
    {

        TimeSpan time = TimeSpan.FromSeconds(Finish.Instance.currentScore);
        currentScoreText.text = time.ToString(@"mm\:ss\:ff");
  
    }
    
    string TimeCalc()
    {
        float total = PlayerPrefs.GetFloat("LevelHighScore" + SceneManager.GetActiveScene().buildIndex);

        float min = Mathf.Floor(total / 60f % 60f);
        float sec = Mathf.Floor(total % 60f);
        float msec = (float)Math.Round((double)Mathf.Floor((total - sec) * 100f), 2);
        string msecString = msec.ToString("00");

        return string.Format("{0}:{1}:{2}", min.ToString("00"), sec.ToString("00"), msec.ToString("00"));
    }
}
