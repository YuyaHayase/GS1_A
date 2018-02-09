using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class yCsvRender : MonoBehaviour {

    public List<string[]> wave = new List<string[]>();


    private void Awake()
    {
        TextAsset csv = Resources.Load("yCSV/Wave") as TextAsset;
        StringReader sr = new StringReader(csv.text);

        CsvReader(wave, sr);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CsvReader(List<string[]> list,StringReader sr)
    {
        while(sr.Peek() != -1)
        {
            string line = sr.ReadLine();
            list.Add(line.Split(','));
        }
    }
}
