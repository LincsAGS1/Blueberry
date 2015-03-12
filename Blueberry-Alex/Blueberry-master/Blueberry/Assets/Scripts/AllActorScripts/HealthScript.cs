using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour 
{
	public float health = 100;
	
	public AudioClip dontFeelGood;
	public AudioClip feelingBlue;
	public AudioClip helpMe;
	public AudioClip deathSound;
	
	
	
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Lose health if infected
		if (this.GetComponent<CollisionManager>().infected == true && health > 0)
		{
			health -= 0.1f;		
		}
		
		
		if (this.GetComponent<CollisionManager>().infected == true && health > 75 && health < 80)
		{
			AudioSource.PlayClipAtPoint(dontFeelGood,transform.position);
		}
		
		if (this.GetComponent<CollisionManager>().infected == true && health > 45 && health <50)
		{
			AudioSource.PlayClipAtPoint(feelingBlue,transform.position);
		}
		
		
		if (this.GetComponent<CollisionManager>().infected == true && health > 25 && health <30)
		{
			AudioSource.PlayClipAtPoint(helpMe,transform.position);
		}
		
		if (this.GetComponent<CollisionManager>().infected == true && health > 0 && health <5)
		{
			AudioSource.PlayClipAtPoint(deathSound,transform.position);
		}
		
		if (this.GetComponent<CollisionManager>().infected == true && health > 0)
			
			
			
			//If dead, become blueberry (can't lose virus)
			if (health <= 0)
		{
			this.GetComponent<CollisionManager>().blueberry = true;
			//Debug.Log(this.name + " Dead");
			//Destroy(gameObject);
			health = 0;
		}
	}
	
	void OnGUI ()
	{
		//If this is a player, display player health
		if (this.tag.Equals ("Player")) 
		{
		    //GUI.Label (new Rect (85, 100, 100, 30),"Player Health:");  
			GUI.Label (new Rect (200, 30, 200, 30), "Player 1 Health:  " + health.ToString ());
		} 
		else if (this.tag.Equals ("Player 2")) 
		{ 
		    GUI.Label (new Rect (480, 30, 200, 30), "Player 2 Health:  " + health.ToString ());

			}
		}
	}


