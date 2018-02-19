using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oEnemyBullet2 : MonoBehaviour {
    public GameObject Bullet;
    float time = 0.0f;
    int i;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, i);
        i += 5;
        //transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        if(time >= 0.1f)
        {
            GameObject BulletPrefab = Instantiate(Bullet) as GameObject;
            BulletPrefab.transform.rotation = Quaternion.Euler(0, 0, i);
            BulletPrefab.transform.position = new Vector3(transform.position.x, transform.position.y, 0);//弾を配置
            time = 0;
        }
        if (i > 360)
        {
            Destroy(gameObject);
        }

	}
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
