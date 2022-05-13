using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TeammateView : MonoBehaviour
{
    public Material joinMaterial;
    public Animator animator;
    public Transform target;
    public float rotateSpeed = 15;
    public enum TeammateState { IDLE, RUN, ATTACK, DEATH };
    public TeammateState ActiveState = TeammateState.IDLE;

    bool following;
    public bool attacking;

    private void Start()
    {
        //TeammateHolder.followMainPlayer += LetsFollow;
        animator = GetComponent<Animator>();

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
            ActiveState = TeammateState.DEATH;
        }

        
        if (collision.gameObject.layer == 7)
        {
            
            StartCoroutine(LetsDie());
            ActiveState = TeammateState.DEATH;

        }

    }

    public void LetsFollow()
    {
        ActiveState = TeammateState.RUN;
        GetComponentInChildren<SkinnedMeshRenderer>().material = joinMaterial;
        following = true;
        transform.parent = Controller.self.playerController.playerView.transform;
        transform.gameObject.layer = 3;
    }



    private void Update()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -5, 5);
        transform.position = pos;
        

        switch (ActiveState)
        {
            case TeammateState.RUN:
                Run();
                break;

            case TeammateState.ATTACK:
                AttackEnemy();
                break;
        }

    }

    void Rotate()
    {
        float tiltAroundY = Input.GetAxis("Horizontal") * rotateSpeed;
        Quaternion targerRot = Quaternion.Euler(0, tiltAroundY, 0);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targerRot, Time.deltaTime * 15);
    }

    void Run()
    {
        if (ActiveState != TeammateState.DEATH)
        {
            animator.SetBool("run", true);
            Rotate();
        }
            
    }

    IEnumerator LetsDie()
    {
        ActiveState = TeammateState.DEATH;
        Controller.self.effectController.ShowEffect(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z));
        transform.parent = null;
        animator.SetTrigger("die");
        gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        Controller.self.playerController.playerView.joinedTeammates.Remove(this.gameObject);
        Controller.self.playerController.OnUpdatePlayerCalled();
        yield return new WaitForSeconds(1.5f);
        transform.DOScale(0, 3);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        
        
    }

    public void AttackEnemy()
    {
        
        if (ActiveState != TeammateState.DEATH)
        {
            attacking = true;
            transform.DOMove(target.position, 1.5f);
            ActiveState = TeammateState.ATTACK;
        }
    }


    public void win()
    {
        animator.SetTrigger("win");
    }

}
