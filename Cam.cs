using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {
   [SerializeField] GameObject targetObj;
   Vector3 targetPos;
   Vector3 roteuler;

   //回転の制限
   [SerializeField] float ANGLE_LIMIT_UP = 0f;
   [SerializeField] float ANGLE_LIMIT_DOWN = 0f;

   void Start() {
       targetObj = GameObject.Find("Player");
       targetPos = targetObj.transform.position;
       roteuler = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0f);
   }

   void Update() {
       rotateCameraAngle();
   }

   //カメラの回転制御
   private void rotateCameraAngle() {
       // targetの移動量分、自分（カメラ）も移動する
       transform.position += targetObj.transform.position - targetPos;
       targetPos = targetObj.transform.position;

       if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.RotateAround(targetPos, Vector3.up, -5f);
        }
        else if (Input.GetKey(KeyCode.RightShift))
        {
            transform.RotateAround(targetPos, Vector3.up, 5f);
        }
              
   }

}