using UnityEngine;
using System.Collections;

public class gotoNextScene : MonoBehaviour {
     GameObject[] players;
	// Use this for initialization
	void Start () {
	 players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            bool dead = true;
        foreach(GameObject g in players)
        {
            if(!g.GetComponent<AgentManager>().blueberry)
            {
                dead = false;
            }
        }
        if(dead)
            {
			Debug.Log("score = " + RandomVirus.points);
			PlayerPrefs.SetInt("Score",RandomVirus.points);
			PlayerPrefs.SetInt("Score2",RandomVirus.points2);
			Debug.Log(PlayerPrefs.GetInt("Score"));

			    //insert level here
			    Application.LoadLevel(Application.loadedLevel+1);
            }
		}
	
}
