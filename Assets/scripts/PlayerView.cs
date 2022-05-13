using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerView : MonoBehaviour
{

    public enum GameState { NONE, GAMESTART, GAMEOVER };
    public GameState ActiveGameState = GameState.NONE;


    public float horizontalSpeed;
    public float movementSpeed;

    public GameObject mainPlayer;
    public Animator animator;

    public List<GameObject> joinedTeammates = new List<GameObject>();

    private void Start()
    {

        animator = GetComponentInChildren<Animator>();
        ActiveGameState = GameState.NONE;


    }

 



    private void Update()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -5f, 5f);
        transform.position = pos;


        switch (ActiveGameState)
        {
            case GameState.GAMESTART:
                transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
                MoveHorizontal();
                break;

            case GameState.GAMEOVER:
                transform.position += Vector3.forward * Time.deltaTime * 0;
                break;

            default:
                transform.position += Vector3.forward * Time.deltaTime * 0;
                break;
        }
        

    }

    void MoveHorizontal()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * horizontalSpeed * Time.deltaTime;
    }

    public void LevelComplete()
    {
        for (int i = 0; i < joinedTeammates.Count; i++)
        {
            joinedTeammates[i].GetComponent<TeammateView>().win();

        }
    }

}
