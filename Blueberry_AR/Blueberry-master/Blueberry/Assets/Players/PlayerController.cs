using UnityEngine;
using System.Collections;

using KinectForWheelchair;

public class PlayerController : MonoBehaviour
{
	public InputController inputController;

    public float speed;

    public int playerNo;
	public bool debugControls = false;

	// Use this for initialization
	void Start ()
	{
		return;
	}
	
	// Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * speed);
        
        if (playerNo == 1)
        {
            if (debugControls)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z - 5);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z + 5);
                }
            }
            
            // Get the input info
            SeatedInfo inputInfo = this.inputController.InputInfo;
            if (inputInfo != null)
            {
                // Set the player position and direction
                if (inputInfo.Features != null)
                {
                    if (inputInfo.Features.Angle > 5)
                    {
                        //this.transform.rotation = new Quaternion(0, 0, this.transform.rotation.z + inputInfo.Features.Angle, 0.1f);
                        this.transform.Rotate(Vector3.back * (inputInfo.Features.Angle / 20));
                    }
                    else if (inputInfo.Features.Angle < -5)
                    {
                        //this.transform.rotation = Quaternion(0, 0, this.transform.rotation.z + inputInfo.Features.Angle, 0.1f);
                        this.transform.Rotate(Vector3.back * (inputInfo.Features.Angle / 20));
                    }
                    //this.transform.rotation = new Quaternion(0, 0, inputInfo.Features.Angle,0);
                    Debug.Log(inputInfo.Features.Angle);
                }
            }
        }
            
		if (playerNo == 2)
		{
            if (debugControls)
            {
                if (Input.GetKey(KeyCode.J))
                {
                    this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z - 5); 
                }
                else if (Input.GetKey(KeyCode.L))
                {
                    this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z + 5);
                }
            }


            if (Input.GetAxis("Joystick Triggers") > 0.05)
			{
                this.transform.Rotate(Vector3.forward * (Input.GetAxis("Joystick Triggers") * 5));
			}
			else if (Input.GetAxis("Joystick Triggers") < -0.05)
			{
                this.transform.Rotate(Vector3.forward * (Input.GetAxis("Joystick Triggers") * 5));
			}
			//Debug.Log(Input.GetAxis("Joystick Triggers"));
        }
    }
}

