using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressScript : MonoBehaviour {

    public string butName;
    bool[] butBools = new bool[4];
    float[] butPress = new float[4];
    string[] butNames = new string[4];
    // Use this for initialization
    void Start () {
        for(int bp = 0; bp < butPress.Length; bp++) {
            butPress[bp] = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //RetString();
    }

    public string RetString() {
        for (int bp = 0; bp < butPress.Length; bp++)
        {
            butPress[bp] = 0;
        }

        float t = Time.deltaTime;
        //Debug.Log(t)
        /*;
        if (Input.GetButton("X"))
        {
            butName = "X";
            //Debug.Log(butName);
            //Debug.Log(t);
            butBools[0] = true;
            butPress[0] = t + 1;
            butNames[0] = "X";
        }
        if (Input.GetButton("Circle"))
        {
            butName = "Circle";
            //Debug.Log(butName);
            //Debug.Log(t);
            butBools[1] = true;
            butPress[1] = t + 1;
            butNames[1] = "Circle";
        }
        if (Input.GetButton("Square"))
        {
            butName = "Square";
            //Debug.Log(butName);
            //Debug.Log("Squ: " + t);
            butBools[2] = true;
            butPress[2] = t + 1;
            butNames[2] = "Square";
        }
        if(Input.GetButton("Triangle"))
        {
            butName = "Triangle";
            //Debug.Log(butName);
            //Debug.Log("Tri: " + t);
            butBools[3] = true;
            butPress[3] = t + 1;
            butNames[3] = "Triangle";
        }
        */
        if (Input.GetButton("Vertical"))
        {
            butName = "V";
            Debug.Log(butName);
            //Debug.Log("Tri: " + t);
            butBools[3] = true;
            butPress[3] = t + 1;
            butNames[3] = "Triangle";
        }
        /*
        float lastButPushed = 0;

        for (int f = 0; f < butPress.Length; f++)
        {
            if (butPress[f] > lastButPushed)
            {
                Debug.Log(butName);
                lastButPushed = butPress[f];
                butName = butNames[f];

            }
        }
        */
        /*
        int trueCount = 0;

        foreach (bool b in butBools) {
            bool temp = b;
            if (temp == true) {
                trueCount++;
            }
        }

        if (trueCount > 1) {
            int lastButPushed = 0;
            for(int f = 0; f < butPress.Length; f++) {
                if (butPress[f] > lastButPushed) {
                    butName = butNames[f];
                    
                }
            }
        }
        */
        //Debug.Log(butName);
        //Debug.Log("X: " + butPress[0]);
        //Debug.Log("Cir: " + butPress[1]);
        //Debug.Log("Tri: " + butPress[3]);
        //Debug.Log("Squ: " + butPress[2]);
        return butName;
    }
}
