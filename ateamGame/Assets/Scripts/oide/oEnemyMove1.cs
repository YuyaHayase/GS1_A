using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oEnemyMove1 : MonoBehaviour{
    float cos;//コサインの値
    public float movement;//移動距離　0.1ぐらいからちょうどいい
    float time = 2;
    bool posflg = false;
    Vector2 enemyPotision;//敵のポジションを取得
    GameObject obj;//※必須
    oBase mother;//※必須
    int direction;//向き※必須
    // Use this for initialization
    void Start () {
        enemyPotision = transform.position;//enemyの座標を取得(必要かどうかは知らないです)
        obj = GameObject.Find("GameObject");//名前を変えて
        oBase tester = obj.GetComponent<oBase>();
    }

    // Update is called once per frame
    void Update()//コサインの値を変更させて移動
    {
        if (transform.tag == "enemy")
        {
            time += Time.deltaTime;
            if (time >= 2.0f)//2秒間隔
            {
                if (posflg == false)
                {
                    //※必須
                    mother = obj.GetComponent<oBase>();
                    direction = mother.Playerposition(transform.position);
                    //※必須
                    posflg = true;
                }
                cos += 0.1f;//コサインの値を増やす
                transform.Translate(movement * direction, Mathf.Cos(cos) * 0.5f, 0);//山なりに移動
                if (transform.position.y <= 0)//自身のY座標が0未満になったとき
                {
                    posflg = false;
                    cos = 0;//コサインの値を0にする
                    time = 0;
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)//床などに当たった時に移動を停止させる(Playerに当たったときはそのまま移動を続けるようにお願いします)
    {
        //tagか何かで判定できるといいかもしれない
        cos = 0;//コサインの値を0にする
        time = 0;
    }
}
