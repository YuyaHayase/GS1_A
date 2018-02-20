using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yCombo : MonoBehaviour {

    [SerializeField,Header("コンボの数を表示")]
    Sprite[] number;

    Image[] comboNumber = new Image[3];
    Image[] characterImage = new Image[5];

    int comboScore = 0;
    float time = 0;
    float alpha = 0.0f;

    public int ComboScore
    {
        set { comboScore = value; }
        get { return comboScore; }
    }

	// Use this for initialization
	void Start () {
        if(number.Length == 0)
            number = Resources.LoadAll<Sprite>("yResources/Number");
        comboNumber[0] = GameObject.Find("ComboNumber1").GetComponent<Image>();
        comboNumber[1] = GameObject.Find("ComboNumber2").GetComponent<Image>();
        comboNumber[2] = GameObject.Find("ComboNumber3").GetComponent<Image>();

        for(int i = 0;i < comboNumber.Length; i++)
        {
            comboNumber[i].color = new Color
                (comboNumber[i].color.r, comboNumber[i].color.g, comboNumber[i].color.b, 0);

        }

        for (int i = 0; i < characterImage.Length; i++)
        {
            int j = i + 1;
            characterImage[i] = transform.FindChild("Character" + j).gameObject.GetComponent<Image>();
            characterImage[i].color = new Color(
                characterImage[i].color.r, characterImage[i].color.g, characterImage[i].color.b, 0);
        }
        comboNumber[1].enabled = false;
        comboNumber[2].enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Combo();
        }

        time += Time.deltaTime;

        if(time >= 1.0f)
        {
            if (alpha > 0)
            {
                alpha -= 0.01f;
                for (int i = 0; i < comboNumber.Length; i++)
                {
                    comboNumber[i].color = new Color(
                        comboNumber[i].color.r, comboNumber[i].color.g, comboNumber[i].color.b, alpha);
                }
                for (int i = 0; i < characterImage.Length; i++)
                {
                    characterImage[i].color = new Color(
                        characterImage[i].color.r, characterImage[i].color.g, characterImage[i].color.b,alpha);
                }
            }
            else
            {
                comboScore = 0;
            }
        }
	}

    public void Combo()
    {
        time = 0;
        alpha = 1.0f;
        StopCoroutine("ComboCoroutine");
        StartCoroutine("ComboCoroutine");
    }

    IEnumerator ComboCoroutine()
    {
        float maxX = 2.0f, maxY = 3.0f;

        comboScore++;

        if (comboScore < 10)//コンボ数が一桁の時
        {
            comboNumber[0].sprite = number[comboScore];
            comboNumber[1].enabled = false;
            comboNumber[2].enabled = false;
        }
        else if (comboScore < 100)//コンボ数が二桁の時
        {
            string s = comboScore.ToString();
            comboNumber[0].sprite = number[int.Parse(s.Substring(s.Length - 1, 1))];//一桁目
            comboNumber[1].sprite = number[int.Parse(s.Substring(s.Length - 2, 1))];//二桁目
            comboNumber[1].enabled = true;
            comboNumber[2].enabled = false;
        }
        else if (comboScore < 999)//コンボ数が三桁の時(今のところ三桁まで)
        {
            string s = comboScore.ToString();
            comboNumber[0].sprite = number[int.Parse(s.Substring(s.Length - 1, 1))];//一桁目
            comboNumber[1].sprite = number[int.Parse(s.Substring(s.Length - 2, 1))];//二桁目
            comboNumber[2].sprite = number[int.Parse(s.Substring(s.Length - 3, 1))];//三桁目
            comboNumber[2].enabled = true;
        }
        else
        {
            comboNumber[0].sprite = number[9];//一桁目
            comboNumber[1].sprite = number[9];//二桁目
            comboNumber[2].sprite = number[9];//三桁目
            comboNumber[0].enabled = true;
            comboNumber[1].enabled = true;
            comboNumber[2].enabled = true;
        }



        //Alphaの値を1にする
        for (int i = 0; i < comboNumber.Length; i++)
        {
            comboNumber[i].color = new Color
                (comboNumber[i].color.r, comboNumber[i].color.g, comboNumber[i].color.b, 1);
        }
        for (int i = 0; i < characterImage.Length; i++)
        {
            characterImage[i].color = new Color(
                characterImage[i].color.r, characterImage[i].color.g, characterImage[i].color.b, 1);
        }



        while (true)//数字がでかくなる
        {
            for (int i = 0; i < comboNumber.Length; i++)
            {
                if (comboNumber[i].transform.localScale.x <= maxX)
                    comboNumber[i].transform.localScale += new Vector3(0.2f, 0, 1);
                if (comboNumber[i].transform.localScale.y <= maxY)
                    comboNumber[i].transform.localScale += new Vector3(0, 0.4f, 1);
            }

            if (comboNumber[0].transform.localScale.x >= maxX
                && comboNumber[0].transform.localScale.y >= maxY)
                break;

            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < comboNumber.Length; i++)
            comboNumber[i].transform.localScale = new Vector3(maxX, maxY, 0);



        while (true)//数字が元の大きさになる
        {
            for (int i = 0; i < comboNumber.Length; i++)
            {
                if (comboNumber[i].transform.localScale.x >= 1)
                    comboNumber[i].transform.localScale += new Vector3(-0.2f, 0, 1);
                if (comboNumber[i].transform.localScale.y >= 1)
                    comboNumber[i].transform.localScale += new Vector3(0, -0.4f, 1);
            }

            if (comboNumber[0].transform.localScale.x <= 1
              && comboNumber[0].transform.localScale.y <= 1)
                break;

            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < comboNumber.Length; i++)
            comboNumber[i].transform.localScale = new Vector3(1, 1, 1);

        yield break;
    }
}
