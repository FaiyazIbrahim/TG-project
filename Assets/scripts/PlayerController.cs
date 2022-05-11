using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public PlayerView playerView;


    public void OnUpdatePlayerCalled()
    {
        if(playerView.joinedTeammates.Count == 0)
        {
            Debug.Log("GameOver");
        }
        else
        {
            Debug.Log("player count: " + playerView.joinedTeammates.Count);
        }
    }
}
