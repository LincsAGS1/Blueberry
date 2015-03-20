using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AgentManager : MonoBehaviour 
{
    public bool collisions = false;
    public bool blueberry = false;
    public bool infected = false;

	public Sprite blueberrySprite;

    public float normalSpeed = 1.0f;
    public float currentSpeed = 1.0f;
    public float virusSpeed = 1.2f;
    public float spdUpMultiplier = 1.2f;
    public float spdDownMultiplier = 0.8f;

    public bool canMove = true;
    public bool speedUp = false;
    public bool slowDown = false;

    public float powerTimer = 0f;
	public float invincTimer = 0f;
    public float speedTimer = 0f;
    public float slowTimer = 0f;
    public float invisTimer = 0f;
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

        #region SpeedManagement
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
                if (agents[i].tag == ("AI"))
                {
                    agents[i].GetComponent<EnemyAI>().moveSpeed = 2;
                }
                else
                {
                    if (this.tag == "Player")
                    {
                        if (speedTimer <= 0f)
                            slowDown = false;
                    }
                }
            }
        }
        #endregion

        //Change the agent to look like a blueberry if they've turned
        if (blueberry)
        {
            this.GetComponent<SpriteRenderer>().sprite = blueberrySprite;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "SpeedUp") 
		{
			Destroy (collision.gameObject);
			//this.gameObject.GetComponent<VirusScript>().
			speedUp = true;
			
			speedTimer = 9.5f;
			powerTimer = 10f;
		}

		if (collision.gameObject.tag == "Bandage") 
		{
			Destroy (collision.gameObject);
			//this.gameObject.GetComponent<VirusScript>().
			this.gameObject.GetComponent<HealthScript>().health += 25;
			if (this.gameObject.GetComponent<HealthScript>().health > 100)
				this.gameObject.GetComponent<HealthScript>().health = 100;

		}
		
		if (collision.gameObject.tag == "Invincible") 
		{
			Destroy (collision.gameObject);
			//this.gameObject.GetComponent<VirusScript>().
			//powertimer = 10f;
			invincTimer = 10f;
		}
		
		if (collision.gameObject.tag == "SlowTime") 
		{
			Destroy (collision.gameObject);
			//this.gameObject.GetComponent<VirusScript>().
			for (int i = 0; i < agents.Length; i ++)
			{
				slowTimer = 9.5f;
				powerTimer = 10f;
                if (agents[i].tag == ("AI"))
                {
                    agents[i].GetComponent<EnemyAI>().moveSpeed = 1;
                }
                else
                { slowDown = true; }
			}
		}

		if (collision.gameObject.tag == "Invisible") 
		{
			Destroy (collision.gameObject);
			//this.gameObject.GetComponent<VirusScript>().
			
			invis = true;
			invisTimer = 10f;
			powerTimer = 10f;
		}

        if (collision.gameObject.tag == "Vaccine")
        {
            Destroy(collision.gameObject);
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
                if (collisions == false)
                {
                   GameObject otherObject = collision.collider.gameObject;

					//if (otherObject.GetComponent<AgentManager>().invinctimer <= 0f)
					//{
                    otherObject.GetComponent<AgentManager>().infected = true;

                    //Only lose infected status 
                    if (!blueberry)
                    { infected = false; } 

                    Debug.Log("Passing to " + collision.collider.name.ToString());

                    otherObject.GetComponent<AgentManager>().collisions = true;
                    StartCoroutine(otherObject.GetComponent<AgentManager>().wait());
                    
                    if (otherObject.name.Contains("Player"))
                    {
                        otherObject.GetComponent<AgentManager>().canMove = false;
                        StartCoroutine(waitHolderPlayer(otherObject));
                    }

                    if (otherObject.name.Contains("AI"))
                    {
                        otherObject.GetComponent<AgentManager>().canMove = false;
                        StartCoroutine(waitHolderAI(otherObject));
                    }
					//}
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

    //What ARE these?
    public IEnumerator wait() // Runs methods every 10 seconds
    {
        yield return new WaitForSeconds(1.0f);

        collisions = false;

        Debug.Log(this.name + " Reset");
    }

    public IEnumerator waitHolderAI(GameObject virusScript) // Runs methods every 10 seconds
    {
        yield return new WaitForSeconds(1.0f);

        virusScript.GetComponent<EnemyAI>().canMove = true;
    }

    public IEnumerator waitHolderPlayer(GameObject virusScript) // Runs methods every 10 seconds
    {
        yield return new WaitForSeconds(1.0f);

        canMove = true;
    }
}