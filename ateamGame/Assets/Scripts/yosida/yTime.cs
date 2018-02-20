using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yTime : MonoBehaviour {

    Image[] timeImage = new Image[5];
    [SerializeField, Header("時間を表示")]
    Sprite[] number;
    int i,j;
    [SerializeField]
    float time = 12.00f;
    bool flgTime = false;//falseになると一時停止

    public bool FlgTime
    {
        set { flgTime = value; }
        get { return flgTime; }
    }

	// Use this for initialization
	void Start () {
        if(number.Length == 0)
            number = Resources.LoadAll<Sprite>("yResources/Number");
        timeImage[0] = GameObject.Find("Time5").GetComponent<Image>();
        timeImage[1] = GameObject.Find("Time4").GetComponent<Image>();
        timeImage[2] = GameObject.Find("Time3").GetComponent<Image>();
        timeImage[3] = GameObject.Find("Time2").GetComponent<Image>();
        timeImage[4] = GameObject.Find("Time1").GetComponent<Image>();

    }

    // Update is called once per frame
    void Update () {
        if(flgTime)
            time -= Time.deltaTime;

        if (Mathf.Max(0.0f, time) == time)//時間が0になるまで
        {
            string s = time.ToString("F2");
            string[] s1 = s.Split('.');
            string s2 = s1[0] + s1[1];//コンマを省いて数字だけ
            j = s2.Length;

            if (time >= 100)
                i = 0;
            else if(time  < 100 && time >= 10)//時間が二桁になると三桁目が消える
            {
                timeImage[0].enabled = false;
                i = 1;
            }
            else if(time < 10)//時間が一桁になると二桁目が消える
            {
                timeImage[1].enabled = false;
                i = 2;
            }

            while (i < timeImage.Length)//時間表示
            {
                timeImage[i].sprite = number[int.Parse(s2.Substring(s2.Length - j, 1))];
                i++;
                j--;
            }

        }
        else//0:00秒
        {
            for (int i = 0; i < timeImage.Length; i++)
            {
                timeImage[i].sprite = number[0];
            }
        }

        #region//デバッグ用
        if (Input.GetKeyDown(KeyCode.Return) && flgTime)
            flgTime = false;
        else if (Input.GetKeyDown(KeyCode.Return) && !flgTime)
            flgTime = true;
        #endregion
    }

}
