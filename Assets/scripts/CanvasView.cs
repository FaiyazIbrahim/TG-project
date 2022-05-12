using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasView : MonoBehaviour
{
    public Image fillImage;
    [Space]
    public GameObject menuPanel;
    public GameObject gamePlayPanel;
    public GameObject gameOverPanel;
    [Space]
    public GameObject wonPanel;
    public GameObject lostPanel;

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
        LevelProgressionBar.self.progressImage = fillImage;
        Controller.self.playerController.playerView.ActiveGameState = PlayerView.GameState.GAMESTART;
        Controller.self.playerController.playerView.mainPlayer.GetComponent<TeammateView>().animator.SetBool("run", true);
        Controller.self.cameraController.MoveToGamePlayCamera();
        menuPanel.SetActive(false);
        gamePlayPanel.SetActive(true);


    }

    public void GameOver(bool win)
    {
        Controller.self.playerController.playerView.ActiveGameState = PlayerView.GameState.GAMEOVER;
        gamePlayPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        if(win)
        {
            Debug.Log("GameOver , won");
            wonPanel.SetActive(true);
        }
        else
        {
            Debug.Log("GameOver , lost");
            lostPanel.SetActive(true);
        }
        
    }

    public void Restart()
    {
        gameOverPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
        menuPanel.SetActive(true);


        wonPanel.SetActive(false);
        lostPanel.SetActive(false);

        SceneManager.LoadScene(0);
    }

}
