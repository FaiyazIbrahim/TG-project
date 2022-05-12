using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineView : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Finish !");
        Controller.self.uiController.canvasView.GameOver(true);
        Controller.self.playerController.playerView.LevelComplete();
    }
}
