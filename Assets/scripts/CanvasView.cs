using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasView : MonoBehaviour
{
    public Image fillImage;
    [Space]
    public GameObject menuPanel;
    public GameObject gamePlayPanel;
    public GameObject gameOverPanel;

    //private void Start()
    //{
    //    if (Controller.self.uiController.canvas == null)
    //    {
    //        Controller.self.uiController.canvas = this.gameObject;
    //    }

    //    LevelProgressionBar.self.progressImage = fillImage;
    //}

    private void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Controller.self.uiController.canvas == null)
        {
            Controller.self.uiController.canvas = this.gameObject;
        }

        LevelProgressionBar.self.progressImage = fillImage;

        menuPanel.SetActive(true);
    }




    public void StartGame()
    {
        Controller.self.playerController.playerView.ActiveGameState = PlayerView.GameState.GAMESTART;
        Controller.self.playerController.playerView.animator.SetBool("run", true);
        
        menuPanel.SetActive(false);
        gamePlayPanel.SetActive(true);

    }

}
