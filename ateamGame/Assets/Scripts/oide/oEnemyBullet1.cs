using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oEnemyBullet1 : MonoBehaviour {//1回転
    float random;
    float f = 0;
    float time = 0.0f;
    bool flg = false;
	// Use this for initialization
	void Start () {
        random = Random.Range(0.1f, 0.3f);//1回転するまでの時間
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time >= random && flg == false)
        {
            rotation();
        }
        transform.Translate(0.4f, 0, 0);
       
	}
    void rotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, f);
        f += 4f;
        if(f == 360)
        {
            flg = true;
            f = 0;
            time = 0;
        }
    }
}
