using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oEnemyBullet8 : MonoBehaviour {//ランダムな軌道
    bool flg = false;
    bool flg2 = false;
    float rotation = 0.0f;
    int randomRotation;//回転する角度
    int randomMode;//移動方法を決める
    float randomTime;//移動時間を決める
    float time = 0.0f;
    float bulletRotation;//処理開始時の角度
    int i = 1;//乱数の最小値
    int count = 0;//カウント
    GameObject player;
    float x, y;//ベクトルx.y
    float angle = 0.0f;//プレイヤーと自身(Enemy)の角度
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(count <= 4)//4以下の場合
        {
            if (flg == false)
            {
                randomMode = Random.Range(i, 3);//移動方法を決める乱数を発生
                randomRotation = Random.Range(40, 73);//回転の角度を決める乱数を発生
                randomTime = Random.Range(2, 4);//移動する秒数を決める乱数を発生
                bulletRotation = transform.rotation.z;//開始時の角度を記録
                flg = true;
            }
            switch (randomMode)
            {
                case 1:
                    oEnemybullet8_rotation(randomRotation, bulletRotation);//回転+移動
                    break;
                case 2:
                    oEnemybullet8_move(randomTime);//移動のみ
                    break;
            }
        }
        else
        {
            oEnemybullet8();
        }

    }
    public void oEnemybullet8_rotation(int i,float f)//回転+移動
    {
        transform.Translate(0.2f, 0, 0);//移動
        transform.rotation = Quaternion.Euler(0,0,rotation);//回転
        rotation += 5;//角度を増やす
        if(rotation  >= i* 5)//乱数で決めた数*5より変化が大きくなったら 
        {
            count++;
            i = 2;//乱数の最小値を変え、2回連続で回転しないようにする
            rotation = 0;
            flg = false;
        }
    }
    public void oEnemybullet8_move(float f)//移動のみ
    {
        time += Time.deltaTime;
        if(time <= f)
        {
            transform.Translate(0.1f, 0, 0);
        }
        else
        {
            count++;
            i = 1;
            flg = false;
            time = 0;
        }
    }
    public void oEnemybullet8()
    {
        if(flg2 == false)
        {
            Debug.Log("a");
            player = GameObject.Find("Enemy1");
            BulletAngle(transform.position, player.transform.position);//角度を計算するメソッドに値を入れる
            transform.rotation = Quaternion.Euler(0, 0, angle);
            flg2 = true;
        }
        transform.Translate(-0.2f, 0, 0);
    }
    float BulletAngle(Vector2 bullerPos, Vector2 playerPos)//タンジェントを使い、弾の向きを変える
    {
        x = bullerPos.x - playerPos.x;
        y = bullerPos.y - playerPos.y;
        angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;//角度を求める
        return angle;//値(角度)を返す 
    }
}
