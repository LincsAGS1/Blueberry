using UnityEngine;
using System.Collections;

using KinectForWheelchair;

public class PlayerController : MonoBehaviour
{

	public InputController inputController;

    public bool kinectEnabled = true;
    public bool controllerEnabled = true;

    public bool canMove = true;

	// Use this for initialization
	void Start ()
	{
		return;
	}
	
	// Update is called once per frame
    void Update()
    {

        if (canMove == true)
        {

            this.transform.Translate(Vector3.up * 0.01f);

            if (controllerEnabled == true)
            {
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

            if (kinectEnabled == true)
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



            return;
        }
        else
        {
            this.transform.Translate(0,0,0);
        }
    }
}
