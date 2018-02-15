using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yMusicManager : MonoBehaviour {

    AudioSource music, soundEffect;
    [SerializeField]
    AudioClip[] bgm;

	// Use this for initialization
	void Start () {
        music = GetComponent<AudioSource>();
        soundEffect = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BGM()
    {

    }
}
