using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oEnemyBullet7 : MonoBehaviour {//エ〇サー

    // Use this for initialization
    void Start () {
        Destroy(gameObject,2);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 100);
    }

}
