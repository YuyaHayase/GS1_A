using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yWaveManagement : MonoBehaviour {
    enum topRow : int { ID = 0,Stage,Wave,Pos,Time};

    public SpriteRenderer enemyA, enemyB, enemyC;

    Vector3[] enemyPos;

    int i = 0, j = 0;
    int stageNumber = 1;
    int waveNumber = 1;
    int[] enemyNumber = new int[3];//Wave毎ごとの敵の数
    int[] enemyAppearanceTime;//敵が出てくる時間
    int number;


    float time = 0;

    string[] enemyID;
    yCsvRender csv;
	// Use this for initialization
	void Start () {
        csv = GameObject.Find("Reference").GetComponent<yCsvRender>();

        EnemyNumber((int)topRow.Wave);
        number = enemyNumber[0] + enemyNumber[1] + enemyNumber[2];

        EnemyTime((int)topRow.Time);
        EnemyPos((int)topRow.Pos);
        EnemyID((int)topRow.ID);


    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;

        //if (time >= enemyAppearance
        //    Time[i] && i < number)
        //{
        //    if (enemyID[i] == "A")
        //        Instantiate(enemyA, enemyPos[i], Quaternion.identity);
        //    if (enemyID[i] == "B")
        //        Instantiate(enemyB, enemyPos[i], Quaternion.identity);
        //    i++;
        //    print(i);
        //    print(number);
        //    if (i == enemyNumber[j])
        //    {
        //        time = 0;
        //        j++;
        //        enemyNumber[j] += i;
        //    }
        //}

    }

    private void EnemyNumber(int x)//Wave毎ごとの敵の数
    {
        for(int y = 1;y < csv.wave.Count; y++)
        {
            if (int.Parse(csv.wave[y][(int)topRow.Stage]) == stageNumber)//ステージの確認
            {
                switch (int.Parse(csv.wave[y][x]))
                {
                    case 1:
                        enemyNumber[0] += 1;
                        break;
                    case 2:
                        enemyNumber[1] += 1;
                        break;
                    case 3:
                        enemyNumber[2] += 1;
                        break;
                }
            }
        }
    }

    private void EnemyTime(int x)//Wave毎ごとの敵の出てくる時間
    {
        enemyAppearanceTime = new int[number];

        for (int y = 1; y < csv.wave.Count; y++)
        {
            if (int.Parse(csv.wave[y][(int)topRow.Stage]) == stageNumber)//ステージの確認
            {
                switch (int.Parse(csv.wave[y][x]))
                {
                    case 1:
                        enemyAppearanceTime[0] += 1;
                        break;
                    case 2:
                        enemyAppearanceTime[1] += 1;
                        break;
                    case 3:
                        enemyAppearanceTime[2] += 1;
                        break;
                }
            }
        }
    }


    private void EnemyPos(int x)//敵の位置の初期化
    {
        int i = 0;
        enemyPos = new Vector3[number];

        for (int y = 1; y < csv.wave.Count; y++)
        {
            if (int.Parse(csv.wave[y][(int)topRow.Stage]) == stageNumber)//ステージの確認
            {
                switch (csv.wave[y][x])
                {
                    case "左":
                        enemyPos[i] = new Vector3(-5.0f,0,0);
                        i++;
                        break;
                    case "右":
                        enemyPos[i] = new Vector3(5.0f, 0, 0);
                        i++;
                        break;
                    default:
                        string[] pos = csv.wave[y][x].Split(',');
                        enemyPos[i] = new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), 0);
                        i++;
                        break;
                }
            }
        }
    }

    private void EnemyID(int x)//敵のIDの初期化
    {
        int i = 0;
        enemyID = new string[number];

        for (int y = 1; y < csv.wave.Count; y++)
        {
            if (int.Parse(csv.wave[y][(int)topRow.Stage]) == stageNumber)//ステージの確認
            {
                enemyID[i] = csv.wave[y][x];
                i++;
            }
        }

    }

    IEnumerator fun1()
    {
        while (true)
        {
            if(time == enemyAppearanceTime[i])
            {

            }

            yield return new WaitForSeconds(1.0f);
            time += 1;
        }
        yield break;
    }
}
