using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oEnemyMove1 : MonoBehaviour {
    float cos;//コサインの値
    float time = 2;
    Vector2 enemyPotision;//敵のポジションを取得
	// Use this for initialization
	void Start () {
        enemyPotision = transform.position;//enemyの座標を取得(必要かどうかは知らないです)
    }

    // Update is called once per frame
    void Update()//コサインの値を変更させて移動
    {
        time += Time.deltaTime;
        if (time >= 1.5f)//2秒間隔
        {
            cos += 0.1f;//コサインの値を増やす
            transform.Translate(0.1f, Mathf.Cos(cos) * 0.5f, 0);//山なりに移動
            if (transform.position.y <= 0)//自身のY座標が0未満になったとき
            {
                cos = 0;//コサインの値を0にする
                time = 0;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)//床などに当たった時に移動を停止させる(Playerに当たったときはそのまま移動を続けるようにお願いします)
    {
        //tagか何かで判定できるといいかもしれない
        cos = 0;//コサインの値を0にする
        time = 0;

    }
    IEnumerator Enemymove1()//使わなくてもよい
    {
        for(int i = 0; i <= 10; i++)
        {
            transform.Translate(0.01f, 0, 0);
            if(i == 10)
            {
                yield break;
            }
            yield return null;
        }
    }
}
