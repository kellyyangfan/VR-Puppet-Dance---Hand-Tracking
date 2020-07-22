using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHandGestures : MonoBehaviour
{
    //public GameObject RightHand;
    //public GameObject LeftHand;
    public GameObject GestureDetector;
    public GameObject DebugText;

    private Vector3 originPos;
    private Vector3 pressPos;

    float pressTime = 0;
    bool press = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("here");
        originPos = transform.position;
        pressPos = new Vector3(transform.position.x, transform.position.y - 0.03f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (press) {
            pressTime += Time.deltaTime;
            //Debug.Log(pressTime);
        }
        else {
            pressTime = 0;
        }

        //setting Right Hand Gesture
        if (pressTime >= 1.5f) // proceed after presssing 3 sec
        {
            GestureDetector.GetComponent<GestureDetection>().Save();
            pressTime = 0;
        }
    }

    void OnCollisionEnter(Collision c)
    {
        Debug.Log("collide");
        //press = true;
        //PressButton();

        //GestureDetector.GetComponent<GestureDetection>().Save();
        if (c.gameObject.tag == "LeftHand") {
            press = true;
            PressButton();
            DebugText.GetComponent<TextMesh>().text = "Left Hand Press Button!\nSaving Right Hand Gesture...";
        }
        if (c.gameObject.tag == "RightHand")
        {
            PressButton();
            DebugText.GetComponent<TextMesh>().text = "Press the button with Left Hand \nto save Right Hand gesture ";
        }


    }
    void OnCollisionExit(Collision c) 
    {
        Debug.Log("collide exit c");
        press = false;
        transform.position = originPos;
    }
    void PressButton() {
        transform.position = pressPos;
    }

}
