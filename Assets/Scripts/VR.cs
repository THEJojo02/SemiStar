using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class VR : MonoBehaviour {

	
	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        StartCoroutine(ActivatorVR("cardboard"));
    }

    public IEnumerator ActivatorVR(string VR)
    {
        UnityEngine.XR.XRSettings.LoadDeviceByName(VR);
        yield return null;
        UnityEngine.XR.XRSettings.enabled = true;
    }


}
