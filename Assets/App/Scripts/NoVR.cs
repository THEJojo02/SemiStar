using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class NoVR : MonoBehaviour {


	void Start () {
        StartCoroutine(DeactivatorVR("none"));
        Screen.orientation = ScreenOrientation.Portrait;
    }
	
    public IEnumerator DeactivatorVR(string NOVR)
    {
        UnityEngine.XR.XRSettings.LoadDeviceByName(NOVR);
        yield return null;
        UnityEngine.XR.XRSettings.enabled = false;
    }
}
