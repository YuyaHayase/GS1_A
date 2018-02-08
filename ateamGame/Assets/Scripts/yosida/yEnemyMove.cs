using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yEnemyMove : MonoBehaviour {

    int type;
    bool flgInCamera = false;
	// Use this for initialization
	void Start () {

        if (Camera.main.transform.position.x > transform.position.x)
            type = 1;
        else
            type = 2;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (type == 1)
            transform.Translate(0.1f, 0, 0);
        else
            transform.Translate(-0.1f, 0, 0);
	}

    private void OnBecameInvisible()
    {
        if (flgInCamera)
        {
            Destroy(gameObject);
        }
    }
    private void OnBecameVisible()
    {
        flgInCamera = true;
    }
}
