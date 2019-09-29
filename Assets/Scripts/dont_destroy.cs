using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class dont_destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public GameObject ob;
    public GameObject ob2;


    // Update is called once per frame
    void Update () {
		DontDestroyOnLoad (ob);
        DontDestroyOnLoad(ob2);
    }
}
