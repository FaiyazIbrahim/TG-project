using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainCharAnimation : MonoBehaviour
{
    Animator animator;
    public float rotateSpeed = 15;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Controller.self.playerController.playerView.joinedTeammates.Add(this.gameObject);
    }

    private void Update()
    {
        Rotate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            StartCoroutine(LetsDie());
        }
    }


    void Rotate()
    {
        float tiltAroundY = Input.GetAxis("Horizontal") * rotateSpeed;
        Quaternion targerRot = Quaternion.Euler(0, tiltAroundY, 0);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targerRot, Time.deltaTime * 15);
    }

    IEnumerator LetsDie()
    {
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

}
