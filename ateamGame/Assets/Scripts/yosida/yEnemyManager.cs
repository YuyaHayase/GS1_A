using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yEnemyManager : MonoBehaviour {

    [SerializeField]
    int enemyHp = 100;

    public int EnemyHP
    {
        set { enemyHp = value; }
        get { return enemyHp; }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
