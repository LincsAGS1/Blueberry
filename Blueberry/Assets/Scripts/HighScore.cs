using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {


	float goBack = 0;
	float highScore = 0;
	string stringToEdit = "Enter Your Name Here!";

	void Start () 
	{

	

	


	}
	
	// Update is called once per frame
	void Update ()
	{

		if (RandomVirus.points >= highScore)
		{
			highScore = RandomVirus.points;
			
		}
		
		if (RandomVirus.points <= highScore)
		{
			highScore = highScore;
			
		}
	
	}

	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width /2 - 140,Screen.height /2 - 250,150,50), "HighScore Table!"  );

		GUI.Box(new Rect(Screen.width /2 - 225,Screen.height /2 - 270,300,450), "" );


		GUI.Label(new Rect(Screen.width /2 - 205,Screen.height /2 - 140,300,700), "HighScore: " + highScore.ToString() );
		
		if (GUI.Button(new Rect(Screen.width /2 - 390,Screen.height /2 + 250,100,50), "Go Back" ))
		{
			goBack = 1;
		}

		if (GUI.Button(new Rect(Screen.width /2 - 170,Screen.height /2 + 250,180,50), "Reset HighScore" ))
		{
			highScore = 0;
			Application.LoadLevel(5);
		}


		stringToEdit = GUI.TextField(new Rect(Screen.width /2 - 92,Screen.height /2 - 140,145,25), stringToEdit, 25);
		if (goBack == 1)
		{
			
			Application.LoadLevel(4);
			
		}

	}


}

