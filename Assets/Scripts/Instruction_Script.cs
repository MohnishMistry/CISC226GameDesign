using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction_Script : MonoBehaviour {

    public GameObject InstructionUI;

    // Use this for initialization
    void Start () {
        InstructionUI.SetActive(true);
	}

    // Update is called once per frame
    void Update() {
        if (InstructionUI.activeSelf == true) { 
            Time.timeScale = 0;
            if (Input.anyKeyDown || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                InstructionUI.SetActive(false);
                Time.timeScale = 1;
            }
        }


    }
}
