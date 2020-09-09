using System;
using System.Collections;
using System.Collections.Generic;
using Uduino;
using UnityEngine;
using Vuforia;

public class LEDWifi : MonoBehaviour{
    public GameObject cube,vbChange;
    public Material High, Low;
    public int PinMode;
    // UduinoManager u; // The instance of Uduino is initialized here


    void Start () {
        // UduinoManager.Instance.OnDataReceived += ReceviedData;

        // VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour> ();
        // for (int i = 0; i < vbs.Length; ++i) { vbs[i].RegisterEventHandler (this); }

         vbChange = GameObject.Find("vbChange");
        vbChange.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbChange.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
 
    }

    public void OnButtonPressed (VirtualButtonBehaviour vb) {
        // if (vb.VirtualButtonName == "vbChange") {
            var cubeRenderer = cube.GetComponent<Renderer> ();
            cubeRenderer.material = new Material (High);

            UduinoManager.Instance.sendCommand ("d", PinMode,1);
            Debug.Log ("Button pressed");
        // }
    }

    public void OnButtonReleased (VirtualButtonBehaviour vb) {
        var cubeRenderer = cube.GetComponent<Renderer> ();
        cubeRenderer.material = new Material (Low);

        UduinoManager.Instance.sendCommand ("d", PinMode,0);
        Debug.Log ("Button released");

    }

    // void ReceviedData (string data, UduinoDevice device) {
    //     Debug.Log (data);
    // }
}
