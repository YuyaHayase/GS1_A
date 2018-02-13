using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oEnemyBullet4 : MonoBehaviour {
    GameObject player;//
    float x, y;//ベクトルx.y
    float angle;//角度
    float cos;//コサインの値
    float f;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");//使うときはPlayerに変える
        BulletAngle(transform.position,player.transform.position);//角度を計算するメソッドに値を入れる
        transform.rotation = Quaternion.Euler(0, 0, angle);//角度を変える
        parabola(transform.position, player.transform.position);//
    }
	
	// Update is called once per frame
	void Update () {
        cos += 0.1f;//コサインの値を変更
        transform.Translate(-f, Mathf.Cos(cos) * 0.5f, 0);//強引な放物線
	}

    float BulletAngle(Vector2 bullerPos,Vector2 playerPos)//タンジェントを使い、弾の向きを変える
    {
        x = bullerPos.x - playerPos.x;
        y = bullerPos.y - playerPos.y;
        angle = Mathf.Atan2(y,x) * Mathf.Rad2Deg;//角度を求める
        return angle;//値(角度)を返す
    }

    float parabola(Vector2 bullerPos, Vector2 playerPos)//強引に放物線を作るメソッド
    {
        f = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));//程よい距離を求める
        f /= 30;
        return f;
    }
}
