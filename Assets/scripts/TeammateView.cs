using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeammateView : MonoBehaviour
{

    bool following;
    private void Start()
    {
        TeammateHolder.followMainPlayer += LetsFollow;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!following)
        {
            GetComponentInParent<TeammateHolder>().FollowPlayer();
            following = true;
        }
        
    }

    void LetsFollow()
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
        following = true;
        //Controller.self.playerController.playerView.joinedTeammates.Add(this.gameObject);
    }
    
}
