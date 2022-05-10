using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlideMovement : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 1f;
    public float slideOffset = 10;
    public float horizonalMoveSpeed;
    public float horizontalLimit = 5;
    public float touchX;
    public float touchY;

    private Vector3 prePos;
    private Vector3 prevPos;

    private Vector3 slidePosiition;
    public Camera mainCam;

    private bool isDown;
    private Vector2 startPosition;

    private Vector3 vel = Vector3.zero;

    public Vector3 delta;

    public bool stopRight, stopLeft;
    public bool isTwoWayRoad = false; 
    public void UpdateMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            prePos = Input.mousePosition;
            prevPos = playerTransform.localPosition;

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = slideOffset;
            //startPosition = mainCam.ScreenToWorldPoint(mousePos);
            isDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDown = false;
            touchX = 0;
            touchY = 0;
        }
    }





    public void FixedUpdateMovement()
    {
        var pos = playerTransform.localPosition;
        if (isDown)
        {
            //Vector3 delta = Input.mousePosition - prePos;
            delta = Input.mousePosition - prePos;
            if (delta.magnitude != 0)
            {
                Vector2 touchDeltaPosition = delta;
                
                touchX = touchDeltaPosition.x;
                touchY = touchDeltaPosition.y;
                touchX = Mathf.Clamp(touchX / 30, -1.0f, 1.0f);
                touchY = Mathf.Clamp(touchY / 30, -1.0f, 1.0f);
                prePos = Input.mousePosition;
            }
            else
            {
                touchX = 0;
                touchY = 0;
            }

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = slideOffset;
            Vector2 endPosition = mainCam.ScreenToWorldPoint(mousePos);

            var dir = (endPosition - startPosition).normalized;

            dir.y = 0;

            var distance = Vector2.Distance(startPosition, endPosition);

            pos.x = Mathf.Clamp(prevPos.x + (dir.x * distance * horizonalMoveSpeed), -horizontalLimit, horizontalLimit);
            if(isTwoWayRoad)
            {
                if(horizontalLimit < 0)
                    pos.x = Mathf.Clamp(prevPos.x + (dir.x * distance * horizonalMoveSpeed), horizontalLimit, 0);
                else 
                    pos.x = Mathf.Clamp(prevPos.x + (dir.x * distance * horizonalMoveSpeed), 0, horizontalLimit);
            }
            if(stopRight)
            {
                pos.x = Mathf.Clamp(pos.x,-horizontalLimit,  -1f);
            }
            else if(stopLeft)
            {
                pos.x = Mathf.Clamp(pos.x, 1f, horizontalLimit);
            }

            //Debug.LogError(pos.x);

        }

        // playerTransform.localPosition = pos;
        playerTransform.localPosition = Vector3.SmoothDamp(playerTransform.localPosition, pos, ref vel, 0.05f);
    }


}
