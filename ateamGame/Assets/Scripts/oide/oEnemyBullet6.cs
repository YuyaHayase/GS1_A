using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oEnemyBullet6 : MonoBehaviour {//スパー〇バレット
    Quaternion f;
    float bulletAngre;//現在の角度を取得
    int i;//Zが180度より大きいと2,違うなら1
    public int maxCount;//反射の最大数
    int count = 0;//反射した回数
	// Use this for initialization
	void Start () {
        bulletAngre =  transform.localEulerAngles.z;
        ii(bulletAngre);
        //transform.rotation = Quaternion.Euler(0, 0, bulletAngre);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0.2f, 0, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        bulletAngre = transform.localEulerAngles.z;//今の角度を取得
        ii(bulletAngre);//判定
        if(other.gameObject.tag != "damage")//弾以外に当たった時
        {
            if (count >= maxCount)//既定の回数だけ反射していたら
            {
                Destroy(gameObject);//オブジェクトを消す
            }

        }
        if (other.gameObject.tag == "topwall")//上の壁
        {
            count += 1;
            if (i == 3)
            {
                bulletAngre = 270;
            }
            else
            {
                bulletAngre *= -1;//角度に-を掛ける
            }
        }
        else if (other.gameObject.tag == "ground")//床
        {
            count += 1;
            if (i == 3)
            {
                bulletAngre = 90;
            }
            else
            {
                bulletAngre *= -1;//角度に-を掛ける
            }
        }
        else if (other.gameObject.tag == "leftwall")//左の壁
        {
            count += 1;
            if (i == 3)
            {
                bulletAngre = 0;
            }
            else
            {
                switch (i)//入射角
                {
                    case 1://180度以下

                        bulletAngre = Mathf.Abs(bulletAngre + 180);
                        bulletAngre *= -1;//角度に-を掛ける
                        break;
                    case 2://180度より大きい
                        bulletAngre = Mathf.Abs(bulletAngre - 180);
                        bulletAngre *= -1;//角度に-を掛ける
                        break;
                }
            }

        }
        else if (other.gameObject.tag == "rightwall")
        {
            count += 1;
            if (i == 3)
            {
                bulletAngre = 180;
            }
            else
            {
                switch (i)//入射角
                {
                    case 1://180度以下

                        bulletAngre = Mathf.Abs(bulletAngre + 180);
                        bulletAngre *= -1;//角度に-を掛ける
                        break;
                    case 2://180度より大きい
                        bulletAngre = Mathf.Abs(bulletAngre - 180);
                        bulletAngre *= -1;//角度に-を掛ける
                        break;
                }
            }
        }
        else if(other.gameObject.tag == "damage2")
        {
            Destroy(gameObject);
        }
        transform.rotation = Quaternion.Euler(0, 0, bulletAngre);
    }
    int ii(float z)
    {
        if(z == 0||z == 90||z== 180||z == 270)
        {
            i = 3;
        }
        else if (z< 180)
        {
            i = 1;
        }
        else
        {
            i = 2;
        }
        return i;
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
