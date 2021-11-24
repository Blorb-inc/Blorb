using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas;

    private void Awake()
    {
        _canvas.enabled = GameManager.tutorials == false; 
        if(_canvas.enabled)
        {
            Time.timeScale = 0f;
        }
    }

    public void Backbtn()
    {
        _canvas.enabled = false;
        GameManager.tutorials = true;
        Time.timeScale = 1f;
    }
}
