using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
	public float maxSpeed = 10f;
	float moveH;
	float moveV;	
	float powertimer = 0f;
	public float invinctimer = 0f;
	GameObject pickerupper;
	public GameObject GameManager;
	public float Virustimer = 0f;


    public bool canMove = true;

	// Use this for initialization
	void Start () 
    {
		GameManager  = GameObject.FindWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () 
    {		
		Virustimer -= Time.deltaTime;
		
		if (Virustimer <= 0f)
		{
			Virustimer = 0f;
			if (this.gameObject.GetComponent<CollisionManager>().speedtimer <= 0f)
			maxSpeed = 5f;
		}
		
	}

	void FixedUpdate () 
	{
        /*if (canMove == true)
        {
            moveH = Input.GetAxis("Horizontal");
            moveV = Input.GetAxis("Vertical");
            
            transform.position += Vector3.right * moveH * maxSpeed * Time.deltaTime;
            transform.position += Vector3.up * moveV * maxSpeed * Time.deltaTime;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }*/
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Pickup") 
		{
			Destroy (col.gameObject);
			//this.gameObject.GetComponent<PlayerMove>().maxSpeed = 8f;
			//this.gameObject.GetComponent<PlayerMove>().maxSpeed = 7f;
			GameManager.GetComponent<RandomVirus>().points += 15;
			powertimer = 10f;
		}
		
		if (col.gameObject.tag == "Invincible") 
		{
			Destroy (col.gameObject);
			//this.gameObject.GetComponent<PlayerMove>().
			powertimer = 10f;
			invinctimer = 10f;
			GameManager.GetComponent<RandomVirus>().points += 15;
		}
		
		if (col.gameObject.tag == "Invisible") 
		{
			Destroy (col.gameObject);
			
			GameManager.GetComponent<RandomVirus>().points += 15;
		}
		
		if (col.gameObject.tag == "SlowTime") 
		{
			Destroy (col.gameObject);
			
			GameManager.GetComponent<RandomVirus>().points += 15;
		}
		
	}

}
