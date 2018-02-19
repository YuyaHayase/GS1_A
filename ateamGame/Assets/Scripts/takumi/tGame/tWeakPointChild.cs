using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tWeakPointChild : MonoBehaviour
{
    [SerializeField, HeaderAttribute("コライダ場所(0左,1右,2下,3上)")]
    private int dirPosition;
    private tWeakPointParent _tWeakPoint;

    void Start()
    {
        //親オブジェクト取得
        _tWeakPoint = transform.parent.gameObject.GetComponent<tWeakPointParent>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "weapon")
        {
            _tWeakPoint.WeponHit(dirPosition);
        }
    }
}
