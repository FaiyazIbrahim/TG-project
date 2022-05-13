using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyView : MonoBehaviour
{

    public Animator animator;

    public enum EnemyState { IDLE, RUN, ATTACK, DEATH };
    public EnemyState EnemyActiveState = EnemyState.IDLE;


    bool attacking;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        EnemyActiveState = EnemyState.IDLE;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            StartCoroutine(LetsDie());
        }
    }


    private void Update()
    {
        switch (EnemyActiveState)
        {
            case EnemyState.RUN:
                Run();
                break;
        }

        float distance = Vector3.Distance(transform.position, Controller.self.playerController.playerView.transform.position);
        
        if(distance <= 10 && !attacking)
        {
            attacking = true;
            StartCoroutine(AttackPlayer());
            
        }
    }


    void Run()
    {
        if (EnemyActiveState != EnemyState.DEATH)
        {
            animator.SetBool("run", true);
            transform.position += transform.forward * Time.deltaTime * 1f;
        }

        
    }


    IEnumerator AttackPlayer()
    {


        int victim = Random.Range(0, Controller.self.playerController.playerView.joinedTeammates.Count);
        var g = Controller.self.playerController.playerView.joinedTeammates[victim].GetComponent<TeammateView>();

        if (g != null && !g.attacking)
        {
            g.attacking = true;
            Controller.self.playerController.playerView.joinedTeammates.Remove(g.transform.gameObject);
            g.target = this.transform;
            g.AttackEnemy();
            EnemyActiveState = EnemyState.RUN;
        }
        else
        {
            StartCoroutine(AttackPlayer());
        }


        yield return null;
        
    }



    IEnumerator LetsDie()
    {
        EnemyActiveState = EnemyState.DEATH;
        //Controller.self.effectController.ShowEffect(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z)); // change  the fx
        animator.SetTrigger("die");
        gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        yield return new WaitForSeconds(1.5f);
        transform.DOScale(0, 3);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

        
    }


}
