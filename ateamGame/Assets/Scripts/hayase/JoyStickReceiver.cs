using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickReceiver : MonoBehaviour {

    public enum PlayStationContoller
    {
        Square,
        Cross,
        Circle,
        Triangle,
        L1,
        R1,
        L2,
        R2,
        Share,
        Option,
        L3,
        R3,
        PSButton,
        TrackPad
    }
	
    public string GetPlayBtn(PlayStationContoller s)
    {
        string jbc = "0";
        switch (s)
        {
            case PlayStationContoller.Square:
                jbc = "0";
                break;
            case PlayStationContoller.Cross:
                jbc = "1";
                break;
            case PlayStationContoller.Circle:
                jbc = "2";
                break;
            case PlayStationContoller.Triangle:
                jbc = "3";
                break;
            case PlayStationContoller.L1:
                jbc = "4";
                break;
            case PlayStationContoller.R1:
                jbc = "5";
                break;
            case PlayStationContoller.L2:
                jbc = "6";
                break;
            case PlayStationContoller.R2:
                jbc = "7";
                break;
            case PlayStationContoller.Share:
                jbc = "8";
                break;
            case PlayStationContoller.Option:
                jbc = "9";
                break;
            case PlayStationContoller.L3:
                jbc = "10";
                break;
            case PlayStationContoller.R3:
                jbc = "11";
                break;
            case PlayStationContoller.PSButton:
                jbc = "12";
                break;
            case PlayStationContoller.TrackPad:
                jbc = "13";
                break;
        }
        return "joystick button " + jbc;
    }

    void Update()
    {
        DisplayButtonName();
    }

    public void DisplayButtonName()
    {
        // □ボタン
        if (Input.GetKey(GetPlayBtn(PlayStationContoller.Square)))
        {
            Debug.Log(PlayStationContoller.Square);
        }

        // ×
        if (Input.GetKey(GetPlayBtn(PlayStationContoller.Cross)))
        {
            Debug.Log(PlayStationContoller.Cross);
        }

        // ◯
        if (Input.GetKey(GetPlayBtn(PlayStationContoller.Circle)))
        {
            Debug.Log(PlayStationContoller.Circle);
        }

        // △
        if (Input.GetKey(GetPlayBtn(PlayStationContoller.Triangle)))
        {
            Debug.Log(PlayStationContoller.Triangle);
        }

        // L1
        if (Input.GetKey(GetPlayBtn(PlayStationContoller.L1)))
        {
            Debug.Log(PlayStationContoller.L1);
        }

        // R1
        if (Input.GetKey(GetPlayBtn(PlayStationContoller.R1)))
        {
            Debug.Log(PlayStationContoller.R1);
        }

        // L2
        if (Input.GetKey(GetPlayBtn(PlayStationContoller.L2)))
        {
            Debug.Log(PlayStationContoller.L2);
        }

        // R2
        if (Input.GetKey(GetPlayBtn(PlayStationContoller.R2)))
        {
            Debug.Log(PlayStationContoller.R2);
        }

        // L3
        if (Input.GetKey(GetPlayBtn(PlayStationContoller.L3)))
        {
            Debug.Log(PlayStationContoller.L3);
        }

        // R3
        if (Input.GetKey(GetPlayBtn(PlayStationContoller.R3)))
        {
            Debug.Log(PlayStationContoller.R3);
        }

        // Share
        if (Input.GetKey(GetPlayBtn(PlayStationContoller.Share)))
        {
            Debug.Log(PlayStationContoller.Share);
        }

        // Option
        if (Input.GetKey(GetPlayBtn(PlayStationContoller.Option)))
        {
            Debug.Log(PlayStationContoller.Option);
        }

        // PSButton
        if (Input.GetKey(GetPlayBtn(PlayStationContoller.PSButton)))
        {
            Debug.Log(PlayStationContoller.PSButton);
        }

        // TrackPad
        if (Input.GetKey(GetPlayBtn(PlayStationContoller.TrackPad)))
        {
            Debug.Log(PlayStationContoller.TrackPad);
        }
    }
}
