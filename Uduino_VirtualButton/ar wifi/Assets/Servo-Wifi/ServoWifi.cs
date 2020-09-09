using System;
using System.Collections;
using System.Collections.Generic;
using Uduino;
using UnityEngine;
using Vuforia;

public class ServoWifi : MonoBehaviour {
    public GameObject cube,VB1,VB2,VB3,VB4;
    public Material B0,B1,B2,B3,B4;
    public int PinMode;
    private float timer = 0.0f;
    private bool isTimerValid = false;
    private string vbName = "";

    void Start () {
        VB1 = GameObject.Find("VB1");
        VB2 = GameObject.Find("VB2");
        VB3 = GameObject.Find("VB3");
        VB1.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        VB1.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);

        VB2.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        VB2.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);

        VB3.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        VB3.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);

 
    }

    public void OnButtonPressed (VirtualButtonBehaviour vb) {

         var cubeRenderer = cube.GetComponent<Renderer> ();
        switch (vb.VirtualButtonName) {
            case "VB1":
                print ("button pressed, starting timer"+ vb.name);
                cubeRenderer.material.color = new Color(0.5f,0,0);
                StartTimer (0.5f, vb.name);
                break;
            case "VB2":
                print ("button pressed, starting timer"+ vb.name);
                cubeRenderer.material.color = new Color(0, 0.5f, 0);

                StartTimer (0.5f, vb.name);
                break;
            case "VB3":
                print ("button pressed, starting timer"+ vb.name);
                cubeRenderer.material.color = new Color(0, 0, 0.5f);
                StartTimer (0.5f, vb.name);
                break;
        }
    }

    public void OnButtonReleased (VirtualButtonBehaviour vb) {
        var cubeRenderer = cube.GetComponent<Renderer> ();
        cubeRenderer.material = new Material (B0);
        UduinoManager.Instance.sendCommand ("servo",0);
        Debug.Log ("Button released");
        InvalidateTimer ();
    }

 public void Update () {
        if (isTimerValid) {
            timer -= Time.deltaTime;

            if (timer <= 0.0f) {
                TimeIsUp ();
                InvalidateTimer ();
            }
        }
    }

    private void StartTimer (float seconds, string vbname) {
        timer = seconds;
        isTimerValid = true;
        vbName = vbname;
    }

    private void InvalidateTimer () {
        timer = 0.0f;
        isTimerValid = false;
    }

    private void TimeIsUp () {
        // do stuff here!
        print ("doing stuff");
        var cubeRenderer = cube.GetComponent<Renderer> ();

        switch (vbName) {
            case "VB1":
                cubeRenderer.material = new Material (B1); //ค้อน
                UduinoManager.Instance.sendCommand ("servo",1);
                break;

            case "VB2":
                cubeRenderer.material = new Material (B2); //กรรไก
                UduinoManager.Instance.sendCommand ("servo",2);
                break;

            case "VB3":
                cubeRenderer.material = new Material (B3); //กระดาษ
                UduinoManager.Instance.sendCommand ("servo",3);
                break;

          
            default:
            cubeRenderer.material = new Material (B0);
            UduinoManager.Instance.sendCommand ("servo",0);
            break;
        }
    }
}
