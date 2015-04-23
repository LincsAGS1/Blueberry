using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class RandomVirus : MonoBehaviour 
{
    public int InitInfected;
	float timer = 0f;
    
	public static int points = 0;
	public static int points2 = 0;
	public int pointsthisround;
    public int[] highscores;
	
	public string testname = "T. Est";

    public GameObject[] players;
    public GameObject player;

	public GameObject p1;
	public GameObject p2;
        
	public Vector3 powerposition;
	public float pickuptimer = 5;
    
    public GameObject powerup;
    public GameObject[] powerups;
    
	public int chosenPower;
	
//	public AudioClip backgroundmusic;
	public float musicvolume = 0.5f;
	float scoretime = 0;
		
	// Use this for initialization
	void Start () 
    {
		PlayerPrefs.DeleteAll ();
		//DontDestroyOnLoad (this);
		//AudioSource.PlayClipAtPoint(backgroundmusic,transform.position);

		//VirusScript virus;
		if (PlayerPrefs.HasKey("Score"))
		{
			//points = PlayerPrefs.GetInt("Score");
		}
								
		//players = players + GameObject.FindGameObjectsWithTag ("Player");
        InitInfected = Random.Range(0, players.Length-1);
		players[InitInfected].GetComponent<AgentManager>().infected = true;
		player = GameObject.FindGameObjectWithTag ("Player");
		
		//virusscript.Blueberry = true;
		//players.gameObject.GetComponent<VirusScript>().Blueberry = true;
		testname = "T Est";
	}
	
	// Update is called once per frame
	void Update () 
    {

		timer += Time.deltaTime;

		//if (player.GetComponent<AgentManager>().infected == false)		
		//points += (int)Time.deltaTime;
			
		pickuptimer -= Time.deltaTime;
		
		if (pickuptimer <= 0f) {
			chosenPower = Random.Range(0, powerups.Length-1);
			Debug.Log("ChosenPower = " + chosenPower);
			powerup = powerups[chosenPower];
			powerposition = new Vector3(Random.Range (-5f, 5f), Random.Range (-5f, 5f), 0f);
			while(Physics2D.OverlapCircle(powerposition,0.5f))
			{
				powerposition = new Vector3(Random.Range (-5f, 5f), Random.Range (-5f, 5f), 0f);
			}
			Debug.Log("hit a wall");
			Instantiate (powerup, powerposition, Quaternion.identity);
			pickuptimer = 10 + Random.Range(-5f,5f);
			
		}
		scoretime += Time.deltaTime;
		if (scoretime > 1) {
			scoretime = 0;
			if(!p1.GetComponent<AgentManager>().infected)
			{
				points+= 5;
			}
			if(!p2.GetComponent<AgentManager>().infected)
			{
				points2+= 5;
			}
		}
		//GetComponent<GUIText>().text = (int)timer + "    seconds                  " + points + "   points";
	}

	void OnGUI()
	{
		GUI.Label (new Rect (400, 12, 400, 100),(int)timer + "    seconds                    points   Player 1: " + points   + "    player 2: " + points2);
		//GUI.Label (new Rect (270, 12, 200, 30),"hi");
	}
	

	

}
