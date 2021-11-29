using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {
   [SerializeField] GameObject targetObj;
   Vector3 targetPos;
 
   void Start() {
       // プレイヤーオブジェクトの情報を取得しtargetObjに格納
       targetObj = GameObject.Find("Player");
       // プレイヤーの位置をtargetPosに格納
       targetPos = targetObj.transform.position;
   }

   void Update() {
       rotateCameraAngle(); // カメラの追従・回転制御の関数
   }

   // カメラの追従・回転制御
   private void rotateCameraAngle() {
       // プレイヤーの移動分だけカメラも移動
       transform.position += targetObj.transform.position - targetPos;
       targetPos = targetObj.transform.position;
       
       // 左シフトキーが押されたらプレイヤーを中心に左方向に公転
       if (Input.GetKey(KeyCode.LeftShift))
       {
            transform.RotateAround(targetPos, Vector3.up, -5f);
       }
       // 右シフトキーが押されたらプレイヤーを中心に右方向に公転
       else if (Input.GetKey(KeyCode.RightShift))
       {
            transform.RotateAround(targetPos, Vector3.up, 5f);
       }
              
   }

}
