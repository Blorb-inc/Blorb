using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTile : MonoBehaviour
{
    float addTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        addTime += Time.deltaTime * 0.2f;
        Finish.Instance.currentScore += addTime;

    }
}
