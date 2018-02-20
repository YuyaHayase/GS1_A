using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hPlayerMove : MonoBehaviour {

    // アナログスティック
    Vector2 Axis;

    // 武器
    GameObject _child;

    // ジャンプしているか
    bool jumping = false;
    float delta = 0;
    [SerializeField,Tooltip("最低ライン"), Header("最低ライン")]
    float underLine = -4;

    // ジャンプ力
    float jumpPower = 0;

    [SerializeField, Tooltip("ジャンプ力ぅ......ですかね"), Header("ジャンプ力ぅ......ですかね")]
    float HighjumpPower = 0.5f;

    [SerializeField, Tooltip("集中時のジャンプ力"), Header("集中時のジャンプ力")]
    float ZoneInjumpPower = 0.05f;

    [SerializeField, Tooltip("重力"), Header("重力")]
    float Gravity = 9.8f;

    //ジョイスティック
    hJoyStickReceiver jsr;
    hKeyConfigSettings kcs;

    //ジョイスティックの制限
    [SerializeField, Tooltip("左スティック(ボタン)の制限係数"), Header("左スティック(ボタン)の制限係数")]
    float joyLeftAxisComp = 5.0f;
    [SerializeField, Tooltip("右スティックの加速係数"), Header("右スティックの加速係数")]
    float joyRightAxisAccel = 1.5f;

    // Use this for initialization
    void Start () {
        // 子オブジェクトの取得
        _child = transform.FindChild("humer").gameObject;

        jsr = new hJoyStickReceiver();
        kcs = new hKeyConfigSettings();
        kcs.Init();
    }

    // Update is called once per frame
    void Update () {
        float py = 0;
        /*
        y = Vo*t - (g*t^2)/2
            Vo:初速(jumpPowerに分類されるところ)
			t:時間(ジャンプしてからのフレーム数。)
			g:重力加速度(9.8が一般的ですが、1ピクセル当たりの換算距離によります)
        */

        // 集中時以外武器の判定を消す
        if (hKeyConfig.GetKey("Zone") || Input.GetKey(KeyCode.LeftShift)) _child.SetActive(true);
        else _child.SetActive(false);
        
        // ×ボタンが押されたら
        if (hKeyConfig.GetKey("Jump")) jumping=true;
        if (jumping)
        {
            // 集中時ゆっくりになる？やつ
            if (hKeyConfig.GetKey("Zone") || Input.GetKey(KeyCode.LeftShift))
            {
                jumpPower = ZoneInjumpPower;
                delta += Time.deltaTime / 15.0f;
            }
            else
            {
                jumpPower = HighjumpPower;
                delta += Time.deltaTime;
            }

            py = jumpPower - (Gravity * Mathf.Pow(delta, 2) / 2);
            //Debug.Log(py);
        }

        // 最低ラインにキたら
        if (underLine > transform.position.y)
        {
            transform.position = new Vector2(transform.position.x, underLine);
            py = 0;
            delta = 0;
            jumping = false;
        }

        // アクシスの調整 左ステック
        if (Input.GetAxis("Vertical") > 0.8f) jumping = true;
        if (Input.GetAxis("Horizontal") == 0) Axis.x = Input.GetAxis("The Cross Key LeftRight") / joyLeftAxisComp;
        else Axis.x = Input.GetAxis("Horizontal") / joyLeftAxisComp;
        transform.position += new Vector3(Axis.x, py, 0);

        // アクシスの調整 右ステック
        float RightX = Input.GetAxis("Horizontal R") * joyRightAxisAccel;
        float RightY = -Input.GetAxis("Vertical R") * joyRightAxisAccel; ;
        switch (hKeyConfigSettings.mo)
        {
            case 0:
                RightY = -Input.GetAxis("Vertical R") * joyRightAxisAccel;
                break;
            case 1:
                RightY = -Input.GetAxis("Vertical Ru") * joyRightAxisAccel;
//                RightY = -Input.GetAxis("Vertical Ru") * joyRightAxisAccel;
                break;
        }

        // 武器の座標
        _child.transform.position = new Vector3(transform.position.x + RightX,
                                                transform.position.y + RightY,
                                                0);

        // 角度調節
        float rot = Mathf.Atan2(_child.transform.position.y - transform.position.y,
                                _child.transform.position.x - transform.position.x);

        // 右スティックが入力されてないなら
        if (RightX == 0 && RightY==0) _child.transform.rotation = Quaternion.AngleAxis(45,Vector3.forward);
        else _child.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rot * Mathf.Rad2Deg-90);
    }
}
