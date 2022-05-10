using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainCharAnimation : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        
        
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        Controller.self.playerController.playerView.joinedTeammates.Add(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            StartCoroutine(LetsDie());
        }
    }


    IEnumerator LetsDie()
    {
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
