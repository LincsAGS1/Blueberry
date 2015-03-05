using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomVirus : MonoBehaviour 
{
	public GameObject[] players;
	public int InitBlueberry;
	public GameObject Startvirus;
	public bool blueberry;
	public static int points = 0;
	public List<GameObject> playersList;
    private float timer = 0f;

	// Use this for initialization
	void Start () 
    {
		//VirusScript virus;

		playersList = new List<GameObject>();

		playersList.AddRange(GameObject.FindGameObjectsWithTag ("AI"));

		players = playersList.ToArray();

		//players = players + GameObject.FindGameObjectsWithTag ("Player");
        InitBlueberry = Random.Range(0, players.Length);
		Startvirus = players[InitBlueberry];
		Startvirus.GetComponent<CollisionManager>().infected = true;
		//virusscript.Blueberry = true;
		//players.gameObject.GetComponent<VirusScript>().Blueberry = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
		timer += Time.deltaTime;
		points = 5 * (int)timer;
		guiText.text = (int)timer + "    seconds                  " + points + "   points";
	
	}
}
