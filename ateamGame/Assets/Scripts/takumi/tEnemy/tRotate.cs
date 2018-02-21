using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tRotate : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private string rotateDir;

    void Update()
    {
        switch (rotateDir)
        {
            case "X":
                transform.Rotate(transform.right * rotateSpeed * Time.deltaTime);
                break;
            case "Y":
                transform.Rotate(transform.up * rotateSpeed * Time.deltaTime);
                break;
            case "Z":
                transform.Rotate(transform.forward * rotateSpeed * Time.deltaTime);
                break;
        }
    }
}
