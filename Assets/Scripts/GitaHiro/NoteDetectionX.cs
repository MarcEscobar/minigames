﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetectionX : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        //X BUTTON
        if (Input.GetKeyDown(KeyCode.A) && other.gameObject.name == "X(Clone)")
            Destroy(other.gameObject);
        else if (Input.GetKeyDown(KeyCode.A) && other.gameObject.name != "X(Clone)")
            Debug.LogError("Fail!");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Holi");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Adeu siau");
        Debug.LogError("Fail!");
    }
}
