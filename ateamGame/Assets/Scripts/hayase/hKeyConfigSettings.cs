﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

public class hKeyConfigSettings : MonoBehaviour {

    // どのボタンが押されたかのクラス
    hJoyStickReceiver jsr;

    // ReciveKey、キーを変更するか
    bool rKey = false;

    // 表示先
    Text Disp;

    // 変更するキー
    string Id;

    // 保存先
    string FilePath = "";

    // コントローラのモード
    public static int mo;

    [SerializeField, Tooltip("選択等をさせるための決定ボタン"), Header("選択等をさせるための決定ボタン")]
    private hJoyStickReceiver.PlayStationContoller JoyStick_Submit = hJoyStickReceiver.PlayStationContoller.Square;

    // コントローラで決定ボタンを押した際の一瞬でボタンが決定されないようにするためのやつ
    int ctrlmode = 0;
    [SerializeField]
    GameObject SelectedObj;

    // 初期化
    public void Init()
    {
        try
        {
#if UNITY_EDITOR
            FilePath = Application.dataPath + "/Scenes/hayase/" + Application.unityVersion + ".txt";
#endif

#if UNITY_STANDALONE
            FilePath = Application.dataPath + "/" + Application.unityVersion + ".txt";
#endif
            jsr = new hJoyStickReceiver();

            // ファイルからキー状態の設定を読み込む
            FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            ArrayList ar = new ArrayList();
            string s;
            while ((s = sr.ReadLine()) != null) ar.Add(s);
            // 閉じ
            sr.Close();
            fs.Close();
            if(ar.Count == 0)
            {
                // ファイルが有っても中身が無いときのとりあえず入れとくやつ
                hKeyConfig.Config["Jump"] = jsr.GetPlayBtn(hJoyStickReceiver.PlayStationContoller.Cross);
                hKeyConfig.Config["Zone"] = jsr.GetPlayBtn(hJoyStickReceiver.PlayStationContoller.L1);
            }
            else
            {
                // 設定する
                hKeyConfig.Config["Jump"] = ar[0].ToString();
                hKeyConfig.Config["Zone"] = ar[1].ToString();
                mo = int.Parse(ar[2].ToString());
            }


        }
        catch (IOException e)
        {
            Debug.Log(e.Message + "エラー");
            // エラー出たらとりあえず入れる
            hKeyConfig.Config["Jump"] = jsr.GetPlayBtn(hJoyStickReceiver.PlayStationContoller.Cross);
            hKeyConfig.Config["Zone"] = jsr.GetPlayBtn(hJoyStickReceiver.PlayStationContoller.L1);
        }

        Debug.Log("JumpButton: " + hKeyConfig.Config["Jump"] + ", ZoneButton: " + hKeyConfig.Config["Zone"]);
        hKeyConfig.Config["Submit"] = jsr.GetPlayBtn(JoyStick_Submit);
        SetDisp("JumpBtn", hKeyConfig.Config["Jump"]);
        SetDisp("ZoneBtn", hKeyConfig.Config["Zone"]);
    }

    // キー表示
    private void SetDisp(string Name, string txt)
    {
        try
        {
            GameObject.Find(Name).GetComponentInChildren<Text>().text = txt;
        }catch(System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    // キーを入れる
    private void SetKey(string keycode)
    {
        hKeyConfig.Config[keycode] = jsr.ControlButtonKeys();
    }

    // ファイルパスの設定
    void Start()
    {
        Init();
        Modes();
        Modes();

        // セレクトの初期設定
        SelectedObj = GameObject.Find("JumpBtn");
        EventSystem.current.SetSelectedGameObject(SelectedObj);

        Debug.Log(FilePath);

    }

    // キー取得
    void Update()
    {
        if (rKey)
        {
            if (Input.anyKeyDown && ctrlmode == 2)
            {
                Disp.text = jsr.ControlButtonKeys();
                rKey = false;
                SetKey(Id);
                ctrlmode = 0;
            }
        }

        /* キーパッドでどこを選択しているかの表示したりするやつ
         * 決定ボタン( Playstation4 DualShock でいう □ボタンとしてる )
         * でUIのジャンプボタンを選択させ、
         * ジャンプボタン( Playstation4 DualShock でいう ×ボタン)
         * で選択を解除している。
        */
        if (hKeyConfig.GetKeyDown("Submit"))
        {
            if(EventSystem.current.currentSelectedGameObject != null)
            SelectedObj = EventSystem.current.currentSelectedGameObject;
            EventSystem.current.SetSelectedGameObject(SelectedObj);
        }
        if (hKeyConfig.GetKeyUp("Submit") || Input.GetMouseButtonUp(0)) ctrlmode = 2;
        if (hKeyConfig.GetKeyDown("Jump"))
        {
            EventSystem.current.SetSelectedGameObject(null);
            if (ctrlmode == 2) ctrlmode = 0;
        }
    }

    // ボタンを押したら
    public void BtnPressed(Text t)
    {
            rKey = true;
            Disp = t;
            Disp.text = "Press Button!";
            ctrlmode = 1;
    }

    // IDの設定
    public void SetId(string ids)
    {
        Id = ids;
    }

    // タイトルへ
    public void ToTitle()
    {
        FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(hKeyConfig.Config["Jump"]);
        sw.WriteLine(hKeyConfig.Config["Zone"]);
        sw.WriteLine(mo);
        sw.WriteLine(FilePath);
        sw.Close();
        fs.Close();
    }

    // コントローラのモード
    public void Modes()
    {
        mo = 1 - mo;
        string s="";

        switch (mo)
        {
            case 0:
                s = "PlayStation";
                break;
            case 1:
                s = "Other";
                break;
        }

        GameObject.Find("CtrlTxt").GetComponent<Text>().text = s;
    }
}
