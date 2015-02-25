using UnityEngine;
using System.Collections;

public class colourChange : MonoBehaviour {


	public static float redColour = 0;
	public static float blueColour = 0;
	public static float greenColour = 0;


	

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (redColour == 1)
		{
			gameObject.renderer.material.color = Color.red;
			blueColour = 0;
			greenColour = 0;
			
		}
		
		if (blueColour == 1)
		{
			gameObject.renderer.material.color = Color.blue;
			greenColour = 0;
			redColour = 0;
		}
		
		if (greenColour == 1)
		{
			gameObject.renderer.material.color = Color.green;
			blueColour = 0;
			redColour = 0;

			
		}
	
	}


	void makeRed()
	{
		redColour = 1;
	}

	void makeBlue()
	{
		blueColour = 1;
	}

	void makeGreen()
	{	
		greenColour = 1;
	}
}

