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

    // 初期化
    public void Init()
    {
        try
        {
            jsr = new JoyStickReceiver();

            // ファイルからキー状態の設定を読み込む
            FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string[] s = new string[10];
            int cnt = 0;
            while ((s[cnt] = sr.ReadLine()) != null)
            {
                Debug.Log(s[cnt]);
                cnt++;
            }
            Debug.Log("aa");

            // 設定する
            KeyConfig.Config["Jump"] = s[0];
            KeyConfig.Config["Zone"] = s[1];
        }
        catch (IOException e)
        {
            Debug.Log(e.Message);
            // エラー出たらとりあえず入れる
            KeyConfig.Config["Jump"] = jsr.GetPlayBtn(JoyStickReceiver.PlayStationContoller.Cross);
            KeyConfig.Config["Zone"] = jsr.GetPlayBtn(JoyStickReceiver.PlayStationContoller.L1);
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
        FilePath = Application.dataPath + "/Scenes/hayase/"+ Application.unityVersion + ".txt";
        Debug.Log(FilePath);
        Init();
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
}
