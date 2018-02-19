using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tEnemyFade : MonoBehaviour
{
    private SpriteRenderer spr;
    private bool fadeIn = true;
    private float alpha = 0;

    [SerializeField]
    private float timeXross; //倍率

    yEnemyManager enemyManager;
    yWaveManagement waveManagement;
    GameObject parent;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.color = new Color(spr.color.r,spr.color.g,spr.color.b,alpha);

        enemyManager = transform.parent.GetComponent<yEnemyManager>();
        waveManagement = GameObject.Find("Wave").GetComponent<yWaveManagement>();
        parent = transform.root.gameObject;
    }

    void Update()
    {
        if(fadeIn)
        {
            Debug.Log("aaa");
            alpha += Time.deltaTime * timeXross;
            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, alpha);
            if (alpha >= 1) fadeIn = false;
        }
        if(transform.position.x <= -50 || transform.position.x >= 50)
        {//もし吉田が変えた場合はここも変えろ
            waveManagement.enemyNumber[waveManagement.WaveNumber - 1]--;
            Destroy(parent.gameObject);
        }
    }
}
