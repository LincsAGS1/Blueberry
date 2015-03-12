﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomVirus : MonoBehaviour {
	
	
	public GameObject[] players;
	public int InitBlueberry;
	public GameObject Startvirus;
	public bool blueberry;
	float timer = 0f;
	public int points = 0;
	public int pointsthisround;
	public List<GameObject> playersList;
	public GameObject powerup;
	public Vector3 powerposition;
	public float pickuptimer = 5;
	public int[] highscores;
	public string testname = "T. Est";
	public GameObject[] powerups;
	public List<GameObject> poweruplist;
	public GameObject prefab;
	public GameObject prefab1;
	public GameObject prefab2;
	public GameObject prefab3;
	public GameObject prefab4;
	public int chosenpower;
	public GameObject player;
	
	
	// Use this for initialization
	void Start () {
		
		//VirusScript virus;
		if (PlayerPrefs.HasKey("Score"))
		{
			points = PlayerPrefs.GetInt("Score");
		}
		
		//powerposition = new Vector3 (0, 0, -0.5);
		playersList = new List<GameObject>();
		poweruplist = new List<GameObject>();
		
		
		playersList.AddRange(GameObject.FindGameObjectsWithTag ("Player"));
		playersList.AddRange (GameObject.FindGameObjectsWithTag ("Player 2"));
		playersList.AddRange(GameObject.FindGameObjectsWithTag ("AI"));
		poweruplist.Add(prefab);
		poweruplist.Add (prefab1);
		poweruplist.Add (prefab2);
		poweruplist.Add (prefab3);
		poweruplist.Add (prefab4);
		powerups = poweruplist.ToArray();
		players = playersList.ToArray();
		
		
		
		//players = players + GameObject.FindGameObjectsWithTag ("Player");
		InitBlueberry = ChooseAtRandom(players);
		Startvirus = players[InitBlueberry];
		Startvirus.GetComponent<CollisionManager>().infected = true;
		player = GameObject.FindGameObjectWithTag ("Player");
		player = GameObject.FindGameObjectWithTag ("Player 2");
		
		

			InvokeRepeating("AddToPoints", 1.0f, 1.0f);
		
		
		//virusscript.Blueberry = true;
		//players.gameObject.GetComponent<VirusScript>().Blueberry = true;
		
		testname = "T Est";
		
	}
	
	
	
	// Update is called once per frame
	void Update () {
		chosenpower = ChooseAtRandom(powerups);
		powerup = powerups[chosenpower];
		powerposition = new Vector3(Random.Range (-5f, 5f), Random.Range (-5f, 5f), 0f);
		
		timer += Time.deltaTime;
		//if (player.GetComponent<CollisionManager>().infected == false)		
			//	points += (int)Time.deltaTime;
			
			
			pickuptimer -= Time.deltaTime;
		
		if (pickuptimer <= 0f) {
			Instantiate (powerup, powerposition, Quaternion.identity);
			pickuptimer = 10 + Random.Range(-5f,5f);
		}
		
		
		
		AddScore (testname, points);
		GetHighScores();
	}
	
	void AddScore(string name, int score)
	{
		
		//Will check the score and see if it is higher than the pevious high score. Multiple scores, and custom names, will be put in shortly.
		int newScore;
		string newName;
		int oldScore;
		string oldName;
		newScore = score;
		newName = name;
		
		
		
		for(int i=0;i<10;i++)
		{
			if(PlayerPrefs.HasKey(i+"HScore"))
			{
				if(PlayerPrefs.GetInt(i+"HScore")<newScore)
				{ 
					// new score is higher than the stored score
					oldScore = PlayerPrefs.GetInt(i+"HScore");
					oldName = PlayerPrefs.GetString(i+"HScoreName");
					PlayerPrefs.SetInt(i+"HScore",newScore);
					PlayerPrefs.SetString(i+"HScoreName",newName);
					newScore = oldScore;
					newName = oldName;
				}
			}
			else
			{
				PlayerPrefs.SetInt(i+"HScore",newScore);
				PlayerPrefs.SetString(i+"HScoreName",newName);
				newScore = 0;
				newName = "";
			}
		}
	}
	
	
	
	void GetHighScores()
	{
		for(int i = 0; i < 10; i++)
		{
			//Display the high score. Use this after the AddScore function
			guiText.text = (int)timer + "    seconds                  " + points + "   points \n" + PlayerPrefs.GetString(i + "HScoreName") + " has a high score of: " + PlayerPrefs.GetInt(i + "HScore");
			
		}
		if (Input.GetKeyDown("j"))
		{
			PlayerPrefs.DeleteAll();			
		}
		
	}
	
	void AddToPoints () {
		if (player.GetComponent<CollisionManager>().infected == false)
		points += 5;
	}
	
	
	public static int ChooseAtRandom (GameObject[] array)
	{
		return Random.Range(0, array.Length);
	}
	
	
	
}