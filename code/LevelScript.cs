using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {
	//bool nextLevel;

	float newHealth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{


		bool playerOne = GameObject.FindGameObjectWithTag("Player");
		bool playerTwo = GameObject.FindGameObjectWithTag("player2");

		//float newHealth = this.GetComponent<HealthScript>().health;

		//check playone and playertwo are dead and if so reload level 
		
		if (this.GetComponent<CollisionManager>().blueberry = true && playerOne == false && playerTwo == false)
		{
			Application.LoadLevel (Application.loadedLevel);

		}

		//if either playerone or playertwo are still alive and theres no more A.I then load nextlevel

		if (playerOne == true || playerTwo == true && this.GetComponent<CollisionManager>().blueberry == false)
		{
			Application.LoadLevel (Application.loadedLevel + 1);

			//&& GameObject.FindGameObjectsWithTag("AI") == false
		}

	}
	
}



/*if (Input.GetKeyDown(KeyCode.A))
		{
			loadNextLevel();
		}

		public void loadNextLevel()
		{
			Application.LoadLevel (Application.loadedLevel + 1);
		}
		
		public void restartLevel()
		{
			Application.LoadLevel (Application.loadedLevel);
		}

*/