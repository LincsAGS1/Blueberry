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
			    //insert level here
			    Application.LoadLevel(Application.loadedLevel+1);
            }
		}
	
}
