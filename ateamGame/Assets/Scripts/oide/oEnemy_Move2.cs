using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oEnemy_Move2 : MonoBehaviour {
    bool flg = false;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if(flg == false)
        {
            StartCoroutine("Enemymove2");
            
        }
        else if(flg == true)
        {
            //StopCoroutine("Enemymove2");
        }
    }
    IEnumerator Enemymove2()
    {
        for (int i = 0; i <= 50; i++)
        {
            transform.Rotate(0, 0, i * 0.01f);
            if(i >= 50)
            {
                transform.position = new Vector3(transform.position.x + i * 0.00005f, transform.position.y, transform.position.z);
                //transform.rotation = Quaternion.Euler(0, 0, 0);
                //StopCoroutine("Enemymove2");
                flg = true;
                yield break;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator Enemyspeaddown()
    {
        for (int i = 50; i <= 0; i--)
        {
            transform.Rotate(0, 0, Mathf.Round(i * 0.01f));
            transform.position = new Vector3(transform.position.x + i * 0.00005f, transform.position.y, transform.position.z);
            if (i <= 10)
            {
                Debug.Log("a");
                StopCoroutine("Enemyspeaddown");
                yield break;
            }
            yield return new WaitForSeconds(0.2f);
        }

    }
}
