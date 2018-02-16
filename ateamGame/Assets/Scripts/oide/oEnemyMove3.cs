using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oEnemyMove3 : MonoBehaviour {
    float time = 0.0f;
    public float attackTime;//移動間隔
    public GameObject bullet;//弾
    GameObject bulletInstance;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time >= attackTime)
        {
            StartCoroutine("Enemymove3");
        }
        
	}
    IEnumerator Enemymove3()
    {
        for (int i = 0; i <= 10; i++)
        {
            transform.Translate(0.01f, 0, 0);
            if (i == 10)
            {
                bulletInstance = Instantiate(bullet) as GameObject;
                bulletInstance.transform.position = new Vector3(transform.position.x + 1, transform.position.y , 0);//弾を配置
                time = 0;
                StopCoroutine("Enemymove3");
                yield break;
                
            }
            yield return new WaitForSeconds(0.2f);
            //yield return null;
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
