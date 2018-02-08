using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    // アナログスティック
    Vector2 Axis;

    // 武器
    GameObject _child;

    // ジャンプしているか
    bool jumping = false;
    float delta = 0;

    // ジャンプ力
    [SerializeField, Tooltip("ジャンプ力ぅ......ですかね")]
    float jumpPower = 2;

    [SerializeField, Tooltip("重力")]
    float Gravity = 9.8f;

	// Use this for initialization
	void Start () {
        _child = transform.FindChild("humer").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        float py = 0;
        /*
        y = Vo*t - (g*t^2)/2
				当の公式を利用します。

				Vo:初速(jumpPowerに分類されるところ)
				t:時間(ジャンプしてからのフレーム数。)
				g:重力加速度(9.8が一般的ですが、1ピクセル当たりの換算距離によります)
        */
        if (Input.GetKeyDown("joystick button 1")) jumping=true;
        if (jumping)
        {
            delta += Time.deltaTime;
            py = jumpPower - (Gravity * Mathf.Pow(delta, 2) / 2);
            //Debug.Log(py);
        }
        if (-4 > transform.position.y)
        {
            transform.position = new Vector2(transform.position.x, -4);
            py = 0;
            delta = 0;
            jumping = false;
        }

        Axis.x = Input.GetAxis("Horizontal") / 5.0f;
        transform.position += new Vector3(Axis.x, py, 0);

        float RightX = Input.GetAxis("Horizontal R") * 1.5f;
        float RightY = -Input.GetAxis("Vertical R") * 1.5f;

        _child.transform.position = new Vector3(transform.position.x + RightX,
                                                transform.position.y + RightY,
                                                0);

        float rot = Mathf.Atan2(_child.transform.position.y - transform.position.y,
                                _child.transform.position.x - transform.position.x);
        if (RightX == 0&&RightY==0) _child.transform.rotation = Quaternion.AngleAxis(45,Vector3.forward);
        else _child.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rot * Mathf.Rad2Deg-90);
    }
}
