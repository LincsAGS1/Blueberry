using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionManager : MonoBehaviour 
{
    public bool collisions = false;
    public bool blueberry = false;
    public bool infected = false;
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

	void Start () {
		//this.SendMessage ("Blueberry", false);
		gamecontroller = GameObject.FindGameObjectWithTag("GameController");
		//Players = gamecontroller.GetComponent<RandomVirus>().players;
		
		
		playersList1 = new List<GameObject>();
		playersList1.AddRange(GameObject.FindGameObjectsWithTag ("Player"));
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
			this.GetComponent<PlayerMove>().maxSpeed = 5f;	
		
		else if (speedtimer > 0f && this.tag == ("Player"))
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

    void OnCollisionEnter2D(Collision2D collision)
    {


		if (collision.gameObject.tag == "Pickup") 
		{
			Destroy (collision.gameObject);
			//this.gameObject.GetComponent<VirusScript>().
			this.gameObject.GetComponent<PlayerMove>().maxSpeed = 10f;
			
			speedtimer = 9.5f;
			powertimer = 10f;
		}
		
		if (collision.gameObject.tag == "Invincible") 
		{
			Destroy (collision.gameObject);
			//this.gameObject.GetComponent<VirusScript>().
			//powertimer = 10f;
			invinctimer = 10f;
		}
		
		if (collision.gameObject.tag == "SlowTime") 
		{
			Destroy (collision.gameObject);
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
		if (collision.gameObject.tag == "Invisible") 
		{
			Destroy (collision.gameObject);
			//this.gameObject.GetComponent<VirusScript>().
			
			invis = true;
			invistimer = 10f;
			powertimer = 10f;
		}
		
		if (collision.gameObject.tag == "Vaccine") 
		{
			Destroy (collision.gameObject);
			//Checks that the person who picked up the powerup has the virus, then finds the closest player/AI next to them, and gives the new guy the virus.
			if (this.gameObject.GetComponent<CollisionManager>().infected == true && this.gameObject.GetComponent<CollisionManager>().blueberry == false)
			{
				
				this.gameObject.GetComponent<CollisionManager>().infected = false;
				newinfected.gameObject.GetComponent<CollisionManager>().infected = true;
			}
		}



        Debug.Log("pass 0");
        if (collision.collider.name.Contains("Enemy") || collision.collider.name.Contains("Player"))
        {
            Debug.Log("pass 1");
            if (infected == true)
            {
                Debug.Log("pass 2");
                if (collisions == false)
                {
                    Debug.Log("pass 3");
                    GameObject otherObject = collision.collider.gameObject;

                    otherObject.GetComponent<CollisionManager>().infected = true;

                    //Only lose infected status 
                    if (!blueberry)
                    { infected = false; } 

                    Debug.Log("Passing to " + collision.collider.name.ToString());

                    otherObject.GetComponent<CollisionManager>().collisions = true;

                    StartCoroutine(otherObject.GetComponent<CollisionManager>().wait());

                    if (otherObject.name.Contains("Player"))
                    {
                        otherObject.GetComponent<PlayerMove>().canMove = false;

                        StartCoroutine(waitHolderPlayer(otherObject));
                    }

                    if (otherObject.name.Contains("Enemy"))
                    {
                        otherObject.GetComponent<EnemyAI>().canMove = false;

                        StartCoroutine(waitHolderAI(otherObject));
                    }
                }
            }
        }
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

    public IEnumerator wait() // Runs methods every 10 seconds
    {
        yield return new WaitForSeconds(6.0f);

        collisions = false;

        Debug.Log(this.name + " Reset");
    }

    public IEnumerator waitHolderAI(GameObject virusScript) // Runs methods every 10 seconds
    {
        yield return new WaitForSeconds(6.0f);

        virusScript.GetComponent<EnemyAI>().canMove = true;
    }

    public IEnumerator waitHolderPlayer(GameObject virusScript) // Runs methods every 10 seconds
    {
        yield return new WaitForSeconds(6.0f);

        virusScript.GetComponent<PlayerMove>().canMove = true;
    }
}