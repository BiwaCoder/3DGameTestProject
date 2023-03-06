using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickController : MonoBehaviour
{
    public FixedJoystick joystick;
    public Rigidbody _charcterRigidBody;
    private Vector3 m_Direction;

    [SerializeField] int moveSpeed = 1;
    [SerializeField] float LimitSpeed;
    [SerializeField] float smooth = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        MoveCharcterToWardTargetPostion(moveSpeed);
        //速度を超えている場合
        if (_charcterRigidBody.velocity.magnitude > LimitSpeed)
        {
            //現在の方向に対して制限速度での移動を上限とする
            _charcterRigidBody.velocity = _charcterRigidBody.velocity.normalized * LimitSpeed;
        }
    }


    void MoveCharcterToWardTargetPostion(int speed)
    {

        //カメラに垂直なベクトルを計算
        var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        //ジョイスティックの縦は、カメラに対して前後ろに移動させ
        //ジョイスティックの左右は、カメラの左右に対応するようにベクトル計算する
        Vector3 direction = cameraForward * joystick.Vertical + Camera.main.transform.right * joystick.Horizontal;

        _charcterRigidBody.AddForce(direction * moveSpeed, ForceMode.Impulse);

        if (!direction.Equals(Vector3.zero))
        {
            //体の向きを滑らかに変更する
            Quaternion rotation = Quaternion.LookRotation(direction);
            this.transform.rotation = rotation;
        }
    }
}
