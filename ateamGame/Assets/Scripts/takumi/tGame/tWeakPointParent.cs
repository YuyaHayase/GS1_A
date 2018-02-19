using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tWeakPointParent : MonoBehaviour
{
    //当たっているか(多重判定防止)
    private bool isHit;
    private yHpgage _yHpgage;

    [SerializeField, HeaderAttribute("弱点の向き(0左,1右,2下,3上)")]
    private int weakpointDir;

    //private 
    void Start()
    {
        _yHpgage = transform.parent.transform.FindChild("EnemyHPgage").transform.FindChild("HPbar").GetComponent<yHpgage>();
    }

    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "weapon" && isHit)
        {
            //武器が通り抜けたよ
            isHit = false;
        }
    }

    //子から呼ばれる武器が当たった処理
    public void WeponHit(int dir)
    {
        //多重反応防止
        if (!isHit)
        {
            isHit = true;

            if (dir == weakpointDir)
            {//弱点ヒット、処理をここに
                Debug.Log("弱点HIT");
                _yHpgage.EnemyDamage(30);
            }
            else
            {//通常ヒット、処理をここに
                Debug.Log("通常ヒット");
                _yHpgage.EnemyDamage(10);
            }
        }
    }
}
