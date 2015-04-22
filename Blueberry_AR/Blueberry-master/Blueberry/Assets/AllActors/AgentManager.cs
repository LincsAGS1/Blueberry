using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AgentManager : MonoBehaviour 
{
    public bool collisions = false;
    public bool blueberry = false;
    public bool infected = false;

	public Sprite blueberrySprite;

    private float normalSpeed = 1.0f;
    public float currentSpeed = 1.0f;
    private float virusSpeed = 1.2f;
    private float spdUpMultiplier = 1.2f;
    private float spdDownMultiplier = 0.8f;

    private float stallTime = 5.0f;

    public bool canMove = true;
    public bool speedUp = false;
    public bool slowDown = false;

    public float powerTimer = 0f;
	public float invincTimer = 0f;
    public float speedTimer = 0f;
    public float slowTimer = 0f;
    public float invisTimer = 0f;
    public float stallTimer = 0f;
    public bool invis = false;

    public GameObject[] agents;
    public List<GameObject> agentList;

	void Start () 
    {
		//this.SendMessage ("Blueberry", false);
        //Players = gamecontroller.GetComponent<RandomVirus>().players;
				
		agentList = new List<GameObject>();
        agentList.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        agentList.AddRange(GameObject.FindGameObjectsWithTag("AI"));
        agents = agentList.ToArray();
	}
	
	// Update is called once per frame
    void Update()
    {
        //Players = gamecontroller.GetComponent<RandomVirus>().players;
        slowTimer -= Time.deltaTime;
        speedTimer -= Time.deltaTime;
        powerTimer -= Time.deltaTime;
        invincTimer -= Time.deltaTime;
        invisTimer -= Time.deltaTime;
        stallTimer -= Time.deltaTime;

        #region Speed Management
        if (canMove)
        {
            if (this.GetComponent<AgentManager>().infected)
            {
                currentSpeed = virusSpeed;
            }
            else
            {
                currentSpeed = normalSpeed;
            }

            if (speedUp)
            {
                currentSpeed *= spdUpMultiplier;
            }

            if (slowDown)
            {
                currentSpeed *= spdDownMultiplier;
            }
        }
        else
        { currentSpeed = 0.0f; }
        #endregion

        #region Powerup Handling
        if (invisTimer <= 0f)
        {
            invisTimer = 0f;
            invis = false;
        }

        if (speedTimer <= 0.1f && this.tag == ("Player"))
            speedUp = false;

        else if (speedTimer > 0f && this.tag == ("Player"))
            speedUp = true;

        if (slowTimer <= 0.1f)
        {
            for (int i = 0; i < agents.Length; i++)
            {
                slowDown = false;
            }
        }
        #endregion

        if (stallTimer <= 0)
        {
            canMove = true;
            collisions = true;
        }

        //Change the agent to look like a blueberry if they've turned
        if (blueberry)
        {
            this.GetComponent<SpriteRenderer>().sprite = blueberrySprite;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<CircleCollider2D>().enabled = true;
            this.GetComponent<CircleCollider2D>().radius = 2.0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "SpeedUp") 
		{
			//this.gameObject.GetComponent<VirusScript>().
			speedUp = true;
			
			speedTimer = 9.5f;
			powerTimer = 10f;
		}

		if (collision.gameObject.tag == "Bandage") 
		{
			//this.gameObject.GetComponent<VirusScript>().
			this.gameObject.GetComponent<HealthScript>().health += 25;
			if (this.gameObject.GetComponent<HealthScript>().health > 100)
				this.gameObject.GetComponent<HealthScript>().health = 100;

		}
		
		if (collision.gameObject.tag == "Invincible") 
		{
			//this.gameObject.GetComponent<VirusScript>().
			//powertimer = 10f;
			invincTimer = 10f;
		}
		
		if (collision.gameObject.tag == "SlowTime") 
		{
			//this.gameObject.GetComponent<VirusScript>().
			for (int i = 0; i < agents.Length; i ++)
			{
				slowTimer = 9.5f;
				powerTimer = 10f;
                slowDown = true;
			}
		}

		if (collision.gameObject.tag == "Invisible") 
		{
			//this.gameObject.GetComponent<VirusScript>().
			invis = true;
			invisTimer = 10f;
			powerTimer = 10f;
		}

        if (collision.gameObject.tag == "Vaccine")
        {
            //Checks that the person who picked up the powerup has the virus, then finds the closest player/AI next to them, and gives the new guy the virus.
            if (this.gameObject.GetComponent<AgentManager>().infected == true && this.gameObject.GetComponent<AgentManager>().blueberry == false)
            {

                this.gameObject.GetComponent<AgentManager>().infected = false;
                GetClosestEnemy(agents).gameObject.GetComponent<AgentManager>().infected = true;
            }
        }
        
        if (collision.collider.tag.Contains("AI") || collision.collider.tag.Contains("Player"))
        {
            if (infected == true)
            {
                if (collisions == true)
                {
                   GameObject otherObject = collision.collider.gameObject;

					//if (otherObject.GetComponent<AgentManager>().invinctimer <= 0f)
					//{
                    otherObject.GetComponent<AgentManager>().infected = true;

                    //Only lose infected status 
                    if (!blueberry)
                    { infected = false; } 

                    Debug.Log("Passing to " + collision.collider.name.ToString());
                    
                    otherObject.GetComponent<AgentManager>().canMove = false;
                    otherObject.GetComponent<AgentManager>().collisions = false;
                    otherObject.GetComponent<AgentManager>().stallTimer = stallTime;
                }
            }
        }
    }

	Transform GetClosestEnemy(GameObject[] enemies)
	{
		Transform minPos = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		foreach (GameObject obj in enemies)
		{
			float dist = Vector3.Distance(obj.transform.position, currentPos);
			if (dist < minDist && dist > 0.01)
			{
				minPos = obj.transform;
				minDist = dist;
			}
		}
        return minPos;
	}
}