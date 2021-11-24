using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpotlight : MonoBehaviour
{
    private PlayerController _player;

    public void Setup(PlayerController player)
    {
        _player = player;
    }


    void Update()
    {
        if(_player != null)
        {
            transform.position = _player.transform.position;
        }
    }
}
