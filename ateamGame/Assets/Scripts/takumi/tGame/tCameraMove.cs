using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tCameraMove : MonoBehaviour
{
    private GameObject player;
    private float xPos, yPos;

    [SerializeField]
    private float xMax, xMin, yMax, yMin;

    [SerializeField]
    private float yPosDown;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //プレイヤーの位置取得
        float xPlayerPos = player.transform.position.x, yPlayerPos = player.transform.position.y;

        //最大最小処理
        if (xPlayerPos <= xMin) xPos = xMin;
        else if (xPlayerPos >= xMax) xPos = xMax;
        else xPos = xPlayerPos;

        if (yPlayerPos <= yMin) yPos = yMin;
        else if (yPlayerPos >= yMax) yPos = yMax;
        else yPos = yPlayerPos;

        transform.position = new Vector3(xPos, yPos - yPosDown, -10);
    }
}
 