using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeammateHolder : MonoBehaviour
{

    public List<GameObject> teammates = new List<GameObject>();

    public delegate void Follow();
    public static event Follow followMainPlayer;

    public void FollowPlayer()
    {
        if (followMainPlayer != null)
        {
            followMainPlayer();
            Debug.Log("folowing player");


            for (int i = 0; i < teammates.Count; i++)
            {
                Controller.self.playerController.playerView.joinedTeammates.Add(teammates[i]);
            }
        }



    }
}
