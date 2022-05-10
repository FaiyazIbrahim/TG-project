using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TeammateView : MonoBehaviour
{
    public Material joinMaterial;
    public Material deathMaterial;
    public Animator animator;
    
    public enum TeammateState { IDLE, RUN, ATTACK, DEATH };
    public TeammateState ActiveState = TeammateState.IDLE;

    bool following;
    float movementSpeed;

    private void Start()
    {
        TeammateHolder.followMainPlayer += LetsFollow;
        animator = GetComponentInChildren<Animator>();

        ActiveState = TeammateState.IDLE;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!following && collision.gameObject.layer == 3)
        {
            GetComponentInParent<TeammateHolder>().FollowPlayer();
            following = true;
        }
        
        if(collision.gameObject.layer == 6)
        {
            StartCoroutine(LetsDie());
        }
        
    }

    void LetsFollow()
    {
        //GetComponent<MeshRenderer>().material.color = Color.yellow;
        ActiveState = TeammateState.RUN;
        GetComponentInChildren<SkinnedMeshRenderer>().material = joinMaterial;
        following = true;
        transform.parent = Controller.self.playerController.playerView.transform;

    }



    private void Update()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -2.2f, 2.2f);
        transform.position = pos;

        switch (ActiveState)
        {
            case TeammateState.RUN:
                Run();
                break;
        }

    }

    void Run()
    {
        //movementSpeed = Controller.self.playerController.playerView.movementSpeed;
        //transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
        animator.SetBool("run", true);
    }

    IEnumerator LetsDie()
    {
        Debug.Log(" died !");
        Controller.self.effectController.ShowEffect(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z));
        transform.parent = null;
        animator.SetTrigger("die");
        Controller.self.playerController.playerView.joinedTeammates.Remove(this.gameObject);
        yield return new WaitForSeconds(1.5f);
        transform.DOScale(0, 3);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
