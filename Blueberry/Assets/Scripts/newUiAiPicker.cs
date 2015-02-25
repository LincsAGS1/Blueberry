using UnityEngine;
using System.Collections;

public class newUiAiPicker : MonoBehaviour {


	public float AI_Picker = 1;
	string Ai_Name = "AI Character: 1!";
	string Ai_Number = "0";
	float goBack = 0;
	public static float aiCount = 1;

	


	public  Texture aTexture; 
	public  Texture aTexture1;
	public  Texture aTexture2;
	float Ai_Picker = 0;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	void Ai1()
	{
		GUI.DrawTexture(new Rect(Screen.width /2 - 180 ,Screen.height /8,200,200), aTexture, ScaleMode.ScaleToFit, true, 1.5F);
		colourChange.redColour = 1;
		colourChange.greenColour = 0;
		colourChange.blueColour = 0;

	}

	void Ai2()
	{
		GUI.DrawTexture(new Rect(Screen.width /2 - 180 ,Screen.height /8,200,200), aTexture1, ScaleMode.ScaleToFit, true, 1.5F);
		colourChange.blueColour = 1;
		colourChange.redColour = 0;
		colourChange.greenColour = 0;
	
	}

	void Ai3()
	{
		GUI.DrawTexture(new Rect(Screen.width /2 - 180 ,Screen.height /8,200,200), aTexture2, ScaleMode.ScaleToFit, true, 1.5F);
		colourChange.greenColour = 1;
		colourChange.blueColour = 0;
		colourChange.redColour = 0;
		
	}
	
	void OnGUI()
	{
		Ai1 ();


				if (GUI.Button (new Rect (Screen.width / 3, Screen.height / 2, 150, 50), "AI Character 1"))
				{
						AI_Picker = 1;
						Ai_Name = "AI Character: 1!";
						Screen.showCursor = true;	

				 Ai_Picker = 1;

			
				}
		
				//If the second button is clicked, text is generated and AI function is ran
				if (GUI.Button (new Rect ((Screen.width / 4 * 2), Screen.height / 2, 150, 50), "AI Character 3"))
				{
						AI_Picker = 2;
						Ai_Name = "AI Character: 3!";
						Screen.showCursor = true;	

				Ai_Picker = 2;
				}
	
				//If the third button is clicked, text is generated and AI function is ran
				if (GUI.Button (new Rect (Screen.width / 2 - 160, Screen.height / 2, 150, 50), "AI Character 2")) 
				{
						AI_Picker = 3;
						Ai_Name = "AI Character: 2!";
						Screen.showCursor = true;	

			Ai_Picker = 3;
			
				}

		if (Ai_Picker == 1) 
		{
			Ai1();
		}

		if (Ai_Picker == 2) 
		{
			Ai2();
		}

		if (Ai_Picker == 3) 
		{
			Ai3();
		}

	

		// The  label for the name above the AI charcter.	
		GUI.Label(new Rect(Screen.width /2 - 140,Screen.height /8,150,50), Ai_Name );
		//Label for AI number

		GUI.Label(new Rect(Screen.width /2 - 41,Screen.height /2 - 70,150,50), Ai_Number );
		
		GUI.Label(new Rect(Screen.width /2 - 150,Screen.height /2 - 70,150,50), "Number of AI: " );


		if (GUI.Button(new Rect(Screen.width /2 - 390,Screen.height /8,100,50), "Go Back" ))
		{
			goBack = 1;
		}
		
		if (goBack == 1)
		{
			
			Application.LoadLevel(4);
			
		}


		if(GUI.Button(new Rect(Screen.width /2 - 155,Screen.height /2+ 100,40,40), "1"))
		{
			Ai_Number = "1";
			Screen.showCursor = true;	
			  aiCount = 1;

		}
		if(GUI.Button(new Rect(Screen.width /2 - 105,Screen.height /2+ 100,40,40), "2"))
		{
			Ai_Number = "2";
			Screen.showCursor = true;	
			aiCount = 2;
		}
		if(GUI.Button(new Rect(Screen.width /2 - 55,Screen.height /2+ 100,40,40), "3"))
		{
			Ai_Number = "3";	
			Screen.showCursor = true;	
			aiCount = 3;
		}

		if (GUI.Button (new Rect (Screen.width /2 - 125 ,Screen.height /2 + 180,80,50), "Play"))
		{
			Application.LoadLevel(0);	
		}
		
		
	}
}
