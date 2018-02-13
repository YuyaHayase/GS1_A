using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oEnemyMove2 : MonoBehaviour {
    float time = 0.0f;//回転を始める間隔
    bool flg = false;//falseならf(回転の数値)を増やす、trueならfを減らす
    float f;//回転の数値、少しずつ大きくしていく
    float enemyMoveDistance　= 0.0f;//移動距離、値が増えれば移動距離が多くなる
    public float x = 0.001f;//この値だけ移動距離を足していく
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > 2)//2秒後
        {
            if (f <= 40 && flg == false)//回転の大きさが40以下かつ、フラグがfalseなら
            {
                f += 0.1f;//回転の大きさを増やす
            }
            else//回転の大きさが40を超えたら
            {
                flg = true;//減らすためにフラグをtrueにする
            }
            if (flg == true)//フラグがtrueなら
            {
                if (f >= 0)//回転の大きさが0以上なら
                {
                    f -= 0.1f;//減らしていく
                    enemyMoveDistance += x;//移動する値を増やしていく
                    transform.position = new Vector3(transform.position.x + enemyMoveDistance, transform.position.y, transform.position.z);//移動
                }
                else
                {
                    enemyMoveDistance -= x;//移動する値を減らしていく
                    if (enemyMoveDistance <= 1)//移動距離が0以下になったら
                    {
                        time = 0;//時間のカウントを0にする
                        flg = false;//フラグをfalseにする
                    }
                }
            }
            transform.Rotate(0, 0, f);//回転
        }
	}
}
