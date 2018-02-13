using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yHpgage : MonoBehaviour {

    Image hpGage, redGage;

    int hp = 100;
    bool flg = false;

    // Use this for initialization
    void Start () {
        hpGage = GameObject.Find("hpGage").GetComponent<Image>();
        redGage = GameObject.Find("redGage").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Damage(5);
        }
    }

    private void Damage(int x)
    {
        StopCoroutine("DamageCoroutine");
        StopCoroutine("ComboEnd");
        StartCoroutine("DamageCoroutine", x);
    }

    private IEnumerator DamageCoroutine(int x)
    {
        float remaining = (hp - x) / 100.0f;
        hp -= x;
        while (true)
        {
            if (hpGage.fillAmount <= 0)
            {
                yield return StartCoroutine("ComboEnd");
                break;
            }
            //HPgageが少しずつ減っていく
            if (hpGage.fillAmount > remaining)
            {
                hpGage.fillAmount -= 0.01f;
            }
            else
            {
                yield return StartCoroutine("ComboEnd");
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }

    IEnumerator ComboEnd()
    {
        float remaining = redGage.fillAmount;
        print("a");
        while (true)
        {
            if (flg)
                break;
            if (hpGage.fillAmount < redGage.fillAmount)
            {
                redGage.fillAmount -= 0.01f;
            }
            else
            {
                redGage.fillAmount = hpGage.fillAmount;
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }
}
