﻿using UnityEngine;
using System.Collections;

using KinectForWheelchair;

public class MainMenuKinnectScript : MonoBehaviour
{
	
	public InputController inputController;
	
	public bool kinectEnabled = true;
	public bool controllerEnabled = true;
	
	// Use this for initialization
	void Start ()
	{
		return;
	}
	
	// Update is called once per frame
	void Update ()
	{

		
		// Get the input info
		SeatedInfo inputInfo = this.inputController.InputInfo;
		if (inputInfo == null)
			return;
		
		// Set the player position and direction
		if (inputInfo.Features == null)
			return;
		
		//Debug.Log (inputInfo.Features.Position);
		//this.transform.position = new Vector3(inputInfo.Features.Position.x, 0, inputInfo.Features.Position.y) * 5;
		//this.transform.forward = new Vector3(inputInfo.Features.Direction.x, 0, inputInfo.Features.Direction.y) * 5;
		
	
			
			if (inputInfo.Features.Angle > 5)
			{
				//this.transform.rotation = new Quaternion(0, 0, this.transform.rotation.z + inputInfo.Features.Angle, 0.1f);
				this.transform.Rotate(Vector3.back * (inputInfo.Features.Angle / 20));
			Application.LoadLevel(3);
			}
			else if (inputInfo.Features.Angle < -5)
			{
				//this.transform.rotation = Quaternion(0, 0, this.transform.rotation.z + inputInfo.Features.Angle, 0.1f);
				this.transform.Rotate(Vector3.back * (inputInfo.Features.Angle / 20));
			Application.LoadLevel(1);

			}
			//this.transform.rotation = new Quaternion(0, 0, inputInfo.Features.Angle,0);
			Debug.Log(inputInfo.Features.Angle);

		
		
		return;
	}
}