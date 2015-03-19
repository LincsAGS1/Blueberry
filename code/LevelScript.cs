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


		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("AI");

		//float newHealth = this.GetComponent<HealthScript>().health;

		//check playone and playertwo are dead and if so reload level 
		
		if (players[0].GetComponent<CollisionManager>().blueberry == false && players[1].GetComponent<CollisionManager>().blueberry == false)
		{
			Application.LoadLevel (Application.loadedLevel);
		}
		else 

		//if either playerone or playertwo are still alive and theres no more A.I then load nextlevel

			if (enemies[0].GetComponent<CollisionManager>().blueberry == true && enemies[1].GetComponent<CollisionManager>().blueberry == true && enemies[2].GetComponent<CollisionManager>().blueberry == true && enemies[3].GetComponent<CollisionManager>().blueberry == true)
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