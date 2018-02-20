using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oEnemyMove5 : MonoBehaviour {
    public GameObject bullet;//弾
    GameObject bulletInstance;
    GameObject player;
    public float angle = 0.0f;//プレイヤーと自身(Enemy)の角度
    float time = 0.0f;
    //float att2Time = 0.0f;
    int attackStyle = 1;
    //int count = 0;
    public int min;//角度の最小値
    public int max;//角度の最大値
    public float way;//拡散弾をいくつに分けるか
    public int enemyMode = 1;//Playerをロックオンするかしないかの判定。1ならする、2ならしない。
    float [] ii = new float[50];//何度間隔で弾を配置するかの記憶場所
    float x, y;//ベクトルx.y
    
    // Use this for initialization
    void Start () {
        
        player = GameObject.Find("Player");//使うときはPlayerに変える
        //if(enemyMode == 1)
        //{
        //    BulletAngle(transform.position, player.transform.position);//角度を計算するメソッドに値を入れる
        //}
        if(max  == Mathf.Abs(min))//maxとminの絶対値の値が同じなら
        {
            ii[0] = min;//0番に最小値を記憶
        }
        else if(enemyMode == 1)//maxとminの絶対値の値が違い、Playerをロックオンする場合
        {
            //maxとminの絶対値を揃える作業
            max = max + Mathf.Abs(min) / 2;
            min = max * -1;
            ii[0] = min;//0番に最小値を記憶
        }
        if(max + Mathf.Abs(min) > 180)//角度が180度で収まらない場合
        {
            for (int i = 1; i < way; i++)
            {
                ii[i] = ii[i - 1] + (max + Mathf.Abs(min)) / way;//間隔を求めている
            }
        }
        else
        {
            for (int i = 1; i < way; i++)
            {
                ii[i] = ii[i - 1] + (max + Mathf.Abs(min)) / (way - 1);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.tag == "enemy")
        {
            if (enemyMode == 1)
            {
                BulletAngle(transform.position, player.transform.position);//角度を計算するメソッドに値を入れる
            }
            switch (attackStyle)
            {
                case 1:
                    oEnemymove5_Att1();
                    break;
                    //case 2:
                    //    time += Time.deltaTime;
                    //    if(time >= 3)
                    //    {
                    //        oEnemymove5_Att2();
                    //    }
                    //    break;
            }
        }
    }
    float BulletAngle(Vector2 bullerPos, Vector2 playerPos)//タンジェントを使い、弾の向きを変える
    {
        x = bullerPos.x - playerPos.x;
        y = bullerPos.y - playerPos.y;
        angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;//角度を求める
        return angle;//値(角度)を返す 
    }
    public void oEnemymove5_Att1()
    {
        time += Time.deltaTime;
        if (time >= 3)
        {
            if (way == 1)//1wayの時
            {
                bulletInstance = Instantiate(bullet) as GameObject;
                bulletInstance.transform.rotation = Quaternion.Euler(0, 0, 0 + angle - 180);
                bulletInstance.transform.position = new Vector3(transform.position.x, transform.position.y, 0);//弾を配置
            }
            else//way数が1より大きい時
            {
                for (int i = 0; i < way; i++)
                {
                    bulletInstance = Instantiate(bullet) as GameObject;
                    if (enemyMode == 1)
                    {
                        bulletInstance.transform.rotation = Quaternion.Euler(0, 0, ii[i] + angle - 180);
                    }
                    else
                    {
                        bulletInstance.transform.rotation = Quaternion.Euler(0, 0, ii[i] + angle);
                    }
                    bulletInstance.transform.position = new Vector3(transform.position.x, transform.position.y, 0);//弾を配置
                }
            }
            time = 0;
        }
    }
    //失敗作
    //void oEnemymove5_Att2()
    //{
    //    att2Time += Time.deltaTime;
    //    if(att2Time >= 0.0005f)
    //    {
    //        bulletInstance = Instantiate(bullet) as GameObject;
    //        if (enemyMode == 1)
    //        {
    //            bulletInstance.transform.rotation = Quaternion.Euler(0, 0, ii[count] + angle - 180);
    //        }
    //        else
    //        {
    //            bulletInstance.transform.rotation = Quaternion.Euler(0, 0, ii[count] + angle);
    //        }
    //        bulletInstance.transform.position = new Vector3(transform.position.x, transform.position.y, 0);//弾を配置
    //        count += 1;
    //    }
    //    if(count == way)
    //    {
    //        count = 0;
    //        time = 0;
    //    }
    //}
}
