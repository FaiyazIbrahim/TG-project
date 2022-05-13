using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

    public class CameraController : MonoBehaviour
    {
        public Transform target;
        public Transform cameraParent;
        public Camera mainCamera;
        public Transform gamePlaycameraPoint;
    

        public float smoothTime = .5f;
        private float velocity;
        public float clampX = 2;



        private void LateUpdate()
        {
            if(target == null)
            {
                return;
            }

            Move();

            
        }


    public void MoveToGamePlayCamera()
    {
        mainCamera.transform.DOMove(gamePlaycameraPoint.position, 0.2f);
        mainCamera.fieldOfView = 70;
    }


        private void HorizontalUpdate()
        {
            var localCamPos = mainCamera.transform.localPosition;
            localCamPos.x = Mathf.SmoothDamp(localCamPos.x, Mathf.Clamp(Controller.self.playerController.playerView.transform.localPosition.x, -clampX, clampX), ref velocity, smoothTime);
            //localCamPos.x = Mathf.Clamp(Controller.self.playerController.playerView.transform.localPosition.x * 0.65f, -clampX, clampX);

        }


        private void Move()
        {
            var position = target.position;
            cameraParent.position = position;
            var targetRotation = cameraParent.eulerAngles;
            float vel = 0;
            targetRotation.y = Mathf.SmoothDampAngle(targetRotation.y, target.eulerAngles.y, ref vel, 0.08f);
            HorizontalUpdate();
            
        }
    }
