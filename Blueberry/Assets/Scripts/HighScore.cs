using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour 
{
	float goBack = 0;
	float highScore = 0;
	string nameString = "Enter Your Name Here!";

	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

		//if (RandomVirus.points >= highScore)
		{
			highScore = RandomVirus.points;
        }		
	}

	void OnGUI()
	{

	}
}

