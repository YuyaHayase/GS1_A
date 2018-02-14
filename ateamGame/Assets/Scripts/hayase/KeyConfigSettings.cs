using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class KeyConfigSettings : MonoBehaviour {

    // どのボタンが押されたかのクラス
    JoyStickReceiver jsr;

    // ReciveKey、キーを変更するか
    bool rKey = false;

    // 表示先
    Text Disp;

    // 変更するキー
    string Id;

    // 保存先
    string FilePath = "";

    // コントローラのモード
    public static int mo = 0;

    // 初期化
    public void Init()
    {
        try
        {
            FilePath = Application.dataPath + "/Scenes/hayase/" + Application.unityVersion + ".txt";
            jsr = new JoyStickReceiver();

            // ファイルからキー状態の設定を読み込む
            FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            ArrayList ar = new ArrayList();
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                Debug.Log(s);
                ar.Add(s);
            }

            sr.Close();
            fs.Close();
            if(ar.Count == 0)
            {
                Debug.Log("とりま");
                // ファイルが有っても中身が無いときのとりあえず入れとくやつ
                KeyConfig.Config["Jump"] = jsr.GetPlayBtn(JoyStickReceiver.PlayStationContoller.Cross);
                KeyConfig.Config["Zone"] = jsr.GetPlayBtn(JoyStickReceiver.PlayStationContoller.L1);
            }
            else
            {
                Debug.Log("あるやん");
                // 設定する
                KeyConfig.Config["Jump"] = ar[0].ToString();
                KeyConfig.Config["Zone"] = ar[1].ToString();
            }

            
        }
        catch (IOException e)
        {
            Debug.Log(e.Message + "エラー");
            // エラー出たらとりあえず入れる
            KeyConfig.Config["Jump"] = jsr.GetPlayBtn(JoyStickReceiver.PlayStationContoller.Cross);
            KeyConfig.Config["Zone"] = jsr.GetPlayBtn(JoyStickReceiver.PlayStationContoller.L1);
        }

        SetDisp("JumpBtn", KeyConfig.Config["Jump"]);
        SetDisp("ZoneBtn", KeyConfig.Config["Zone"]);
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
        KeyConfig.Config[keycode] = jsr.ControlButtonKeys();
    }

    // ファイルパスの設定
    void Start()
    {
        Debug.Log(FilePath);
        Init();
        Modes();
    }

    // キー取得
    void Update()
    {
        if (rKey)
        {
            if (Input.anyKeyDown)
            {
                Disp.text = jsr.ControlButtonKeys();
                rKey = false;
                SetKey(Id);
            }
        }

    }

    // ボタンを押したら
    public void BtnPressed(Text t)
    {
        rKey = true;
        Disp = t;
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
        sw.WriteLine(KeyConfig.Config["Jump"]);
        sw.WriteLine(KeyConfig.Config["Zone"]);
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
