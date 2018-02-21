using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tBossMove1 : MonoBehaviour
{
    //ボスが今どの状況か
    private int phase = 0;
    //降りてきて止まる場所
    private float stopPos = 14f;

    [SerializeField]
    private float moveSpeed1, moveSpeed2;

    void Start()
    {

    }

    void Update()
    {
        if (phase == 0) //ゆっくり降りていく
        {
            transform.Translate(transform.up * -moveSpeed1 * Time.deltaTime);
            if (transform.position.y <= stopPos) phase = 1;
        }
    }
}
