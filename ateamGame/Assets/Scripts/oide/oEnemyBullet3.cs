using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oEnemyBullet3 : MonoBehaviour {
    public float bulletSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(bulletSpeed, 0, 0);
	}
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
