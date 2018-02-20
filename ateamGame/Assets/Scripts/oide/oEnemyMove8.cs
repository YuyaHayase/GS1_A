using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class oEnemyMove8 : MonoBehaviour {//量産禁止
    float alpha = 1.0f;
    float time = 0.0f;
    float time2 = 0.3f;
    Renderer rend;
    Color color;
    float cos;//コサインの値
    public float movement;//移動距離　0.1ぐらいからちょうどいい
    bool posflg = false;
    Vector2 enemyPotision;//敵のポジションを取得
    GameObject obj;//※必須
    oBase mother;//※必須
    int direction;//向き※必須
    GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        color.r = 1.0f;
        color.g = 1.0f;
        color.b = 1.0f;
        color.a = 1.0f;
        obj = GameObject.Find("Difference");//ベースの入っているオブジェクトを取得、名前を変えて
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.tag == "enemy")
        {
            time2 += Time.deltaTime;
            time += Time.deltaTime;
            if (time2 > 0.3f)
            {
                Enemymove8();
            }
            if (posflg == false)
            {
                //※必須
                mother = obj.GetComponent<oBase>();
                direction = mother.Playerposition(transform.position);
                //※必須
                posflg = true;
                posflg = false;//※必須
            }
            if (time >= 0.1f)
            {
                Renderer rend = GetComponent<SpriteRenderer>();
                rend.material.color = color;
                if (alpha >= 0.05f)
                {
                    alpha -= 0.06f;
                    color.a = alpha;
                }
                else
                {
                    if (direction == 1)
                    {
                        transform.position = new Vector3(player.transform.position.x + 5, player.transform.position.y, player.transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(player.transform.position.x - 5, player.transform.position.y, player.transform.position.z);
                    }
                    time2 = 0.0f;
                    alpha = 1.0f;
                }

                time = 0;
            }
        }
	}
    void Enemymove8()
    {
        transform.Translate(0.05f * direction, 0, 0);
    }

}
