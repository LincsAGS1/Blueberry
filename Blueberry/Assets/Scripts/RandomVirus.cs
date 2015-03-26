using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class RandomVirus : MonoBehaviour 
{
    public int InitInfected;
	float timer = 0f;
    
	public int points = 0;
	public int pointsthisround;
    public int[] highscores;
	
	public string testname = "T. Est";

    public GameObject[] players;
    public GameObject player;
        
	public Vector3 powerposition;
	public float pickuptimer = 5;
    
    public GameObject powerup;
    public GameObject[] powerups;
    
	public int chosenPower;
	
//	public AudioClip backgroundmusic;
	public float musicvolume = 0.5f;
		
	// Use this for initialization
	void Start () 
    {
		//AudioSource.PlayClipAtPoint(backgroundmusic,transform.position);

		//VirusScript virus;
		if (PlayerPrefs.HasKey("Score"))
		{
			points = PlayerPrefs.GetInt("Score");
		}
								
		//players = players + GameObject.FindGameObjectsWithTag ("Player");
        InitInfected = Random.Range(0, players.Length-1);
		players[InitInfected].GetComponent<AgentManager>().infected = true;
		player = GameObject.FindGameObjectWithTag ("Player");
		
        InvokeRepeating("AddToPoints", 1.0f, 1.0f);
		
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
				
		AddScore (testname, points);
		GetHighScores();
	
		points = 5 * (int)timer;
		//GetComponent<GUIText>().text = (int)timer + "    seconds                  " + points + "   points";
	}

	void OnGUI()
	{
		GUI.Label (new Rect (400, 12, 400, 100),(int)timer + "    seconds                  " + points + "   points");
		//GUI.Label (new Rect (270, 12, 200, 30),"hi");
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
			//GetComponent<GUIText>().text = (int)timer + "    seconds                  " + points + "   points \n" + PlayerPrefs.GetString(i + "HScoreName") + " has a high score of: " + PlayerPrefs.GetInt(i + "HScore");
		}
		if (Input.GetKeyDown("j"))
		{
			PlayerPrefs.DeleteAll();			
		}
	}
	
	void AddToPoints () 
    {
		if (player.GetComponent<AgentManager>().infected == false)
		points += 5;
	}
}
