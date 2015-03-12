using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VirusScript : MonoBehaviour {

	public bool Blueberry = false;


	public float maxSpeed = 3f;
	float moveH;
	float moveV;
	public float powertimer = 0f;
	public float invinctimer = 0f;
	GameObject pickerupper;
	public float speedtimer = 0f;
	public GameObject[] Players;
	public float slowtimer = 0f;
	public GameObject gamecontroller;
	public GameObject holder;
	public float invistimer = 0f;
	public bool invis = false;
	public Transform[] Playerslocation;
	public Transform newinfected;
	public List<GameObject> playersList1;


	// Use this for initialization
	void Start () {
		//this.SendMessage ("Blueberry", false);
		gamecontroller = GameObject.FindGameObjectWithTag("GameController");
		//Players = gamecontroller.GetComponent<RandomVirus>().players;


		playersList1 = new List<GameObject>();
		playersList1.AddRange(GameObject.FindGameObjectsWithTag ("Player"));
		playersList1.AddRange(GameObject.FindGameObjectsWithTag ("Player 2"));
		playersList1.AddRange(GameObject.FindGameObjectsWithTag ("AI"));
		Players = playersList1.ToArray();
		Playerslocation = new Transform[Players.Length];
	}
	
	// Update is called once per frame
	void Update () {

		invistimer -= Time.deltaTime;
		if (invistimer <= 0f)
		{
			invistimer = 0f;
			invis = false;
		}
		//Players = gamecontroller.GetComponent<RandomVirus>().players;
		slowtimer -= Time.deltaTime;
		speedtimer -= Time.deltaTime;
		powertimer -= Time.deltaTime;
		invinctimer -= Time.deltaTime;
		if (speedtimer == 0.1f && this.tag == ("Player"))
		if (speedtimer == 0.1f && this.tag == ("Player 2"))
			this.GetComponent<PlayerMove>().maxSpeed = 5f;	

		else if (speedtimer > 0f && this.tag == ("Player"))
	    if (speedtimer == 0.1f && this.tag == ("Player 2"))

			this.GetComponent<PlayerMove>().maxSpeed = 10f;

		if (slowtimer == 0.1f)
		{
			for (int i = 0; i < Players.Length; i ++)
			{	
				if (Players[i].tag == ("AI"))
				{
				Players[i].GetComponent<EnemyAI>().moveSpeed = 4;
				}
				this.GetComponent<PlayerMove>().maxSpeed = 5f;
			}
		}

		for (int i = 0; i < Players.Length; i++)
		{
					
			Playerslocation[i] = Players[i].transform;
			
		}
		newinfected = GetClosestEnemy(Playerslocation);
	
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Pickup") 
		{
			Destroy (col.gameObject);
			//this.gameObject.GetComponent<VirusScript>().
			this.gameObject.GetComponent<PlayerMove>().maxSpeed = 10f;

			speedtimer = 9.5f;
			powertimer = 10f;
		}
		
		if (col.gameObject.tag == "Invincible") 
		{
			Destroy (col.gameObject);
			//this.gameObject.GetComponent<VirusScript>().
			//powertimer = 10f;
			invinctimer = 10f;
		}

		if (col.gameObject.tag == "SlowTime") 
		{
			Destroy (col.gameObject);
			//this.gameObject.GetComponent<VirusScript>().
			for (int i = 0; i < Players.Length; i ++)
			{
				slowtimer = 9.5f;
				powertimer = 10f;
				if (Players[i].tag == ("AI"))
				{
					Players[i].GetComponent<EnemyAI>().moveSpeed = 2;
				}
				this.GetComponent<PlayerMove>().maxSpeed = 5f;
			}
		}
			if (col.gameObject.tag == "Invisible") 
			{
				Destroy (col.gameObject);
				//this.gameObject.GetComponent<VirusScript>().

				invis = true;
				invistimer = 10f;
				powertimer = 10f;
			}

		if (col.gameObject.tag == "Vaccine") 
		{
			Destroy (col.gameObject);
			//Checks that the person who picked up the powerup has the virus, then finds the closest player/AI next to them, and gives the new guy the virus.
			if (this.gameObject.GetComponent<VirusScript>().Blueberry == true)
			{

				this.gameObject.GetComponent<VirusScript>().Blueberry = false;
				newinfected.gameObject.GetComponent<VirusScript>().Blueberry = true;
			}
		}
			
		//	powertimer = 10f;
		
	}

	Transform GetClosestEnemy(Transform[] enemies)
	{
		;
		Transform tMin = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		foreach (Transform t in enemies)
		{
			float dist = Vector3.Distance(t.position, currentPos);
			if (dist < minDist && dist > 0.01)
			{
				tMin = t;
				minDist = dist;
				
			}
		}
		return tMin;
	}
}
