using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndScore : MonoBehaviour {
	public Text score;
	public Text winner;

	// Use this for initialization
	void Start () {
		score.text = "player 1: " + PlayerPrefs.GetInt ("Score") + "\nPlayer 2: " + PlayerPrefs.GetInt("Score2");
		if(PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("Score2"))
		   winner.text = "The winner was\nPlayer 1";
		   else if (PlayerPrefs.GetInt ("Score") < PlayerPrefs.GetInt ("Score2"))
		         winner.text = "The winner was\nPlayer 2";
		         else if (PlayerPrefs.GetInt ("Score") == PlayerPrefs.GetInt ("Score2"))
		         winner.text = "There are no winners only blueberries";
	}

	// Update is called once per frame
	void Update () {
	
	}
}
