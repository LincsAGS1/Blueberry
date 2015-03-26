using UnityEngine;
using System.Collections;

public class gotoNextScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int count = 0;
		foreach (Transform child in transform) {
			if(child.GetComponent<HealthScript>().health > 0)
			{
				count ++;
			}
		}
		Debug.Log (count);
		//if only one player left
		if (count == 1) {
			//insert level here
			Application.LoadLevel(1);
		}
	}
}
