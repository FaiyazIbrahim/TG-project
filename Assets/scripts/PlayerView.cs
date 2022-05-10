using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{

    public float speed;
    public float rotateSpeed;

    private Vector3 vel = Vector3.zero;
    public List<GameObject> joinedTeammates = new List<GameObject>();

    private void Start()
    {
        //if(Controller.self.playerController.playerView == null)
        //{
        //    Controller.self.playerController.playerView = this;
        //}
    }


    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), transform.position.y, 0);
        transform.position += move * speed * Time.deltaTime;
        //transform.localPosition = Vector3.SmoothDamp(transform.localPosition, move, ref move, 0.05f);


        float tiltAroundY = Input.GetAxis("Horizontal") * rotateSpeed;
        Quaternion targerRot = Quaternion.Euler(0, tiltAroundY, 0);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targerRot, Time.deltaTime * 15);
    }
}
