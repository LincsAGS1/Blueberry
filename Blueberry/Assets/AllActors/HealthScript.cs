using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour 
{
	public float health = 100;
	
	public AudioClip dontFeelGood;
	public AudioClip feelingBlue;
	public AudioClip helpMe;
	public AudioClip deathSound;
    
	public Vector3 pos;
	public Texture healthbar;
	public Texture BlueberryHealthbar;
	public float soundplayer = 5f;
		
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		soundplayer -= Time.deltaTime;

		if (this.gameObject.tag == "AI") 
        {
			pos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x-1, transform.position.y + 1, transform.position.z));
			pos.y = Screen.height - pos.y; 
        }

		//Lose health if infected
		if (this.GetComponent<AgentManager>().infected == true && health > 0)
		{
			health -= 1*Time.deltaTime;
		}		
		
		if (this.GetComponent<AgentManager>().infected == true && health > 75 && health < 80 && soundplayer <= 0f)
		{
			AudioSource.PlayClipAtPoint(dontFeelGood,transform.position);
			soundplayer = 5f;
		}
		if (this.GetComponent<AgentManager>().infected == true && health > 45 && health <50 && soundplayer <= 0f)
		{
			AudioSource.PlayClipAtPoint(feelingBlue,transform.position);
			soundplayer = 5f;
		}
		if (this.GetComponent<AgentManager>().infected == true && health > 25 && health <30 && soundplayer <= 0f)
		{
			AudioSource.PlayClipAtPoint(helpMe,transform.position);
			soundplayer = 5f;
		}	
		if (this.GetComponent<AgentManager>().infected == true && health > 0 && health <5 && soundplayer <= 0f)
		{
			AudioSource.PlayClipAtPoint(deathSound,transform.position);
			soundplayer = 5f;
		}
		
        //If dead, become blueberry (can't lose virus)
		if (health <= 0)
		{
			this.GetComponent<AgentManager>().blueberry = true;
			Debug.Log(this.name + " Dead");
			health = 0;
		}
	}
	
	void OnGUI ()
	{
		//If this is a player, display player health
		if (this.tag.Equals("Player"))
		{
			//GUI.Label (new Rect (85, 100, 100, 30),"Player Health:"); 

			if (this.name == "Player 1")
			{
				GUI.Label (new Rect (50, 12, 200, 30),"Player 1 Health");

				if (this.GetComponent<AgentManager>().infected == true)
					GUI.DrawTexture(new Rect(50,10,1*this.health,80),BlueberryHealthbar, ScaleMode.ScaleToFit, true, 10.0F);
				else
				GUI.DrawTexture(new Rect(50,10,1*this.health,80),healthbar, ScaleMode.ScaleToFit, true, 10.0F);
			}
			if (this.name == "Player 2")
			{

				if (this.GetComponent<AgentManager>().infected == true)
					GUI.DrawTexture(new Rect(250,12,1*this.health,80),BlueberryHealthbar, ScaleMode.ScaleToFit, true, 10.0F);
				else
				GUI.DrawTexture(new Rect(250,10,1*this.health,80),healthbar, ScaleMode.ScaleToFit, true, 10.0F);
				GUI.Label (new Rect (250, 12, 200, 30),"Player 2 Health");
			}
		}

			if (this.tag == "AI")
			if (this.GetComponent<AgentManager>().infected == true)
			GUI.DrawTexture(new Rect(pos.x,pos.y,1*this.health/2,40),BlueberryHealthbar, ScaleMode.ScaleToFit, true, 10.0F);
			
			else
			GUI.DrawTexture(new Rect(pos.x,pos.y,1*this.health/2,40),healthbar, ScaleMode.ScaleToFit, true, 10.0F);
	}
}
