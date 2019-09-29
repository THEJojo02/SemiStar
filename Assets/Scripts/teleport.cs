using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teleport : MonoBehaviour {
    private AndroidJavaObject javaClass;
   
 

	public GameObject play;
	Vector3 newpos;

	public GameObject pointer;
	public Vector3 wpos;
	GameObject manager;
	public bool z;
	bool zwischen;
    public Text text;



	public void getpospointer(){
		wpos = pointer.GetComponent<GvrReticlePointer>().CurrentRaycastResult.worldPosition;
		Debug.Log (wpos);
	}
 

	void Update(){
		manager = GameObject.Find ("Manager");
        wait();
        z = manager.GetComponent<Manager_New>().lauf;
        wait();
        if ((z == true) ){
				laufen (z);
				
		}
        text.text = "BluB";
        wait();
        text.text = "Fisch";
	}

	IEnumerator wait(){
		yield return new WaitForSeconds (5f);
	}

    public void laufen(bool zeig)
    {
        wait();
        if (zeig == true) {
            wait();
            getpospointer();
        newpos.x = wpos.x;
        newpos.z = wpos.z;
        newpos.y = 1.66f;
        play.transform.position = newpos;
            wait();
        }
    }
}
