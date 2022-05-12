using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainCharAnimation : MonoBehaviour
{

    private void Start()
    {
        Controller.self.playerController.playerView.joinedTeammates.Add(this.gameObject);
        Controller.self.playerController.playerView.mainPlayer = this.gameObject;
    }

  




}
