using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerView : MonoBehaviour
{

    public float horizontalSpeed;
    public float movementSpeed;
    public float rotateSpeed;
    //public Animator animator;

    public List<GameObject> joinedTeammates = new List<GameObject>();

    private void Start()
    {

        //animator = GetComponent<Animator>();


    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.layer == 6)
    //    {
    //        StartCoroutine(LetsDie());
    //    }
    //}



    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * horizontalSpeed * Time.deltaTime;
        //transform.localPosition = Vector3.SmoothDamp(transform.localPosition, move, ref move, 0.05f);

        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -1.3f, 1.3f);
        transform.position = pos;



        float tiltAroundY = Input.GetAxis("Horizontal") * rotateSpeed;
        Quaternion targerRot = Quaternion.Euler(0, tiltAroundY, 0);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targerRot, Time.deltaTime * 15);



        transform.position += Vector3.forward * Time.deltaTime * movementSpeed;

        //test
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    //Controller.self.effectController.Show(new Vector3(transform.position.x, 5, transform.position.z), 0);
            
        //}

    }

    //IEnumerator LetsDie()
    //{
    //    Debug.Log(" died !");
    //    Controller.self.effectController.ShowEffect(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z));
    //    transform.parent = null;
    //    animator.SetTrigger("die");
    //    Controller.self.playerController.playerView.joinedTeammates.Remove(this.gameObject);
    //    yield return new WaitForSeconds(1.5f);
    //    transform.DOScale(0, 3);
    //    yield return new WaitForSeconds(3);
    //    Destroy(gameObject);
    //}

}
