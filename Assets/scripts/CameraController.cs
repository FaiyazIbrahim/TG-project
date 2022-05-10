using System;
using System.Collections;
using System.Collections.Generic;
//using DG.Tweening;
using UnityEngine;

namespace Cam
{
    [DefaultExecutionOrder(103)]
    public class CameraController : MonoBehaviour
    {
        public Transform target;
        public Transform cameraParent;
        public Camera mainCamera;

        public float smoothTime = .5f;
        private float velocity;

        public Transform gameplayCameraPoint;
        public Transform finishCameraPoint;

        public float clampX = 2;

        private void LateUpdate()
        {
            if(target == null)
            {
                return;
            }

            Move();

            
        }

        private void HorizontalUpdate()
        {
            var localCamPos = mainCamera.transform.localPosition;
            //localCamPos.x = Mathf.SmoothDamp(localCamPos.x, Mathf.Clamp(Controller.self.playerController.playerView.holder.localPosition.x, -clampX, clampX), ref velocity, smoothTime);
            localCamPos.x = Mathf.Clamp(Controller.self.playerController.playerView.transform.localPosition.x * 0.65f, -clampX, clampX);
            //if(!GlobalData.isInPurchasePage)
            //{
            //    mainCamera.transform.localPosition = localCamPos;
            //}
        }


        private void Move()
        {
          //  cameraParent.position = Vector3.SmoothDamp(cameraParent.position, target.position, ref velocity, smoothTime);

            var position = target.position;
          //  position.x = 0;

            cameraParent.position = position;
            var targetRotation = cameraParent.eulerAngles;
            // targetRotation.y = target.eulerAngles.y;
            float vel = 0;
            targetRotation.y = Mathf.SmoothDampAngle(targetRotation.y, target.eulerAngles.y, ref vel, 0.08f);
            cameraParent.eulerAngles = targetRotation;

            HorizontalUpdate();
        }
    }
}