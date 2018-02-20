using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oEnemyMove6 : MonoBehaviour {
    GameObject playerPosition;
    bool flg = false;
    bool flg2 = false;
    bool flg3 = false;
    int i = 1;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.tag == "enemy")
        {
            if (flg == false)
            {
                playerPosition = GameObject.Find("Player");
                if (playerPosition.transform.position.x > transform.position.x)
                {
                    i = 1;
                }
                else
                {
                    i = -1;
                }
                flg = true;
            }
            oEnemymove6();
        }
	}
    void oEnemymove6()
    {
        if(Mathf.Abs(transform.position.x - playerPosition.transform.position.x) > 1 && flg3 == false)
        {
            transform.Translate(0.03f * i, 0, 0);
        }
        else
        {
            flg3 = true;
            if (flg2 == false)
            {
                transform.Translate(0, -0.04f, 0);
            }
            if (flg2 == true && transform.position.y <= 6)
            {
                transform.Translate(0, 0.04f, 0);
            }
            else if(flg2 == true && transform.position.y > 6)
            {
                flg = false;
                flg2 = false;
                flg3 = false;
            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)//床などに当たった時に移動を停止させる
    {
        //tagか何かで判定できるといいかもしれない
        flg2 = true;

    }
}
