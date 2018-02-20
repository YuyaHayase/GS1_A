using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oEnemyMove3 : MonoBehaviour {
    float time = 0.0f;
    public float attackTime;//移動間隔
    public float movement;//移動距離　0.005ぐらいからちょうどいい
    public GameObject bullet;//弾
    GameObject bulletInstance;
    GameObject obj;//※必須
    oBase mother;//※必須
    int direction;//向き※必須
    bool posflg = false;
    // Use this for initialization
    void Start () {
        obj = GameObject.Find("Difference");//ベースの入っているオブジェクトを取得、名前を変えて

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.tag == "enemy")
        {
            time += Time.deltaTime;
            if (time >= attackTime)
            {
                StartCoroutine("Enemymove3");
            }
         }
	}
    IEnumerator Enemymove3()
    {
        if (posflg == false)
        {
            //※必須
            mother = obj.GetComponent<oBase>();
            direction = mother.Playerposition(transform.position);
            //※必須
            posflg = true;
        }
        for (int i = 0; i <= 10; i++)
        {
            transform.Translate(movement * direction, 0, 0);
            if (i == 10)
            {
                bulletInstance = Instantiate(bullet) as GameObject;
                bulletInstance.transform.position = new Vector3(transform.position.x + 1, transform.position.y , 0);//弾を配置
                posflg = false;
                time = 0;
                StopCoroutine("Enemymove3");
                yield break;
            }
            yield return new WaitForSeconds(0.2f);
            //yield return null;
        }
    }

}
