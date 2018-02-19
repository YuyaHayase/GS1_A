using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oBase : MonoBehaviour {
    GameObject player;
    public int i;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public int Playerposition(Vector3 enemypos)
    {
        player = GameObject.Find("Player");
        if (player.transform.position.x > enemypos.x)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
    void save()
    {
        //oBase mother;//※必須
        //obj = GameObject.Find("GameObject");
        //bool posflg = false;//ポジションをとるためのフラグ
        //GameObject obj;//※必須
        //if (posflg == false)
        //{
        //    //※必須
        //    oBase tester = obj.GetComponent<oBase>();
        //    tester.Playerposition(transform.position);
        //    //※必須
        //    posflg = true;
        //}
        //posflg = false;//※必須
    }
}
