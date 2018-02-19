using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oEnemyBullet10 : MonoBehaviour {
    Vector3 pos;
    int i = 1;
    public float distance;//移動距離
    public float speed;//スピード
    // Use this for initialization
    void Start () {
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed * i, 0, 0);
        if(Mathf.Abs(transform.position.x - pos.x) > distance||Mathf.Abs(transform.position.y - pos.y) > distance)
        {
            i *= -1;
        }
        else if(i == -1 && Mathf.Abs(transform.position.x - pos.x) < 0.1f && Mathf.Abs(transform.position.y - pos.y) < 0.1f)
        {
            Destroy(gameObject);
        }
	}
}
