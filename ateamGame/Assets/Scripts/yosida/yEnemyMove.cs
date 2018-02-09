using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yEnemyMove : MonoBehaviour {

    int type;
    bool flgInCamera = false;
    yWaveManagement waveManagement;
	// Use this for initialization
	void Start () {
        waveManagement = GameObject.Find("Wave").GetComponent<yWaveManagement>();


        if (Camera.main.transform.position.x > transform.position.x)
            type = 1;
        else
            type = 2;

        if (Camera.main.transform.position.y < transform.position.y)
            type = 3;


    }

    // Update is called once per frame
    void Update () {
        if (type == 1)
            transform.Translate(0.5f, 0, 0);
        else if (type == 2)
            transform.Translate(-0.5f, 0, 0);
        else
            transform.Translate(0, -0.1f, 0);

	}

    private void OnBecameInvisible()
    {
        if (flgInCamera)
        {
            waveManagement.enemyNumber[waveManagement.WaveNumber - 1]--;
            //print(waveManagement.enemyNumber[waveManagement.WaveNumber - 1]);
            Destroy(gameObject);
        }
    }
    private void OnBecameVisible()
    {
        flgInCamera = true;
    }
}
