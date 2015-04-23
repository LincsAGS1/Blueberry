using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public float rotationLerpScale;
	private float randomTimer = 0.0f;
	private Vector2 randomVec = Random.insideUnitCircle;
        
	void Awake() 
    {

	}
	
	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
    void Update()
    {
        if (this.GetComponent<AgentManager>().canMove == true)
        {
            //Debug.DrawLine(target.position, this.transform.position, Color.yellow);
            //distance = Vector3.Distance(target.position, myTransform.position);

            if (this.GetComponent<AgentManager>().infected == false)
            {
                //If NOT a carrier
                ArrayList agents = new ArrayList();
                ArrayList obstacles = new ArrayList();
                ArrayList avoidVectors = new ArrayList();


                //Avoid things that ARE blueberries with highest priority
                    //Get all enemies & Add each infected to a list of infected
					agents.AddRange(GameObject.FindGameObjectsWithTag("AI"));
                        
                    //Get all players & Add each infected to a list of infected
                    agents.AddRange(GameObject.FindGameObjectsWithTag("Player"));
                    
                    //Get vectors FROM infected TO agent & add to list of vectors
                    //Vector = Destination - Origin
                    foreach(GameObject obj in agents)
                    {
						Vector2 newVector = new Vector2(this.transform.position.x - obj.transform.position.x, this.transform.position.y - obj.transform.position.y);	

						if (obj.GetComponent<AgentManager>().infected && newVector.magnitude < 4 && obj.GetComponent<AgentManager>().invis == false)
						{
							Debug.Log ("infected");
							
							
							//Invert magnitudes of obstacles (further distance means lower priority avoidance)
							//23 is maximum distance within game world (from one corner to diagonal corner)
							//float magnitude = newVector.magnitude;
							newVector.Normalize();
							//newVector *= (23 - magnitude);
							
							//Scale magnuitudes to be 1/5 of those of the infected 
							//(avoiding obstacles is lower priority than avoiding the infected)
							newVector *= 2;
							
							avoidVectors.Add(newVector);
						}       
					}

					randomTimer -= Time.deltaTime;

					if (avoidVectors.Count == 0)
					{
						if ( randomTimer < 0.0f )
						{
							randomVec = Random.insideUnitCircle;
							randomTimer = Random.Range (0.5f, 2.0f);
							avoidVectors.Add (randomVec * 4);
						}
						else 
						{
							avoidVectors.Add (randomVec * 4);
						}
					}
						

                                        
                //Also avoid obstacles, proportional to how close they are. 
                //(Inversely proportional to the magnitude of the vector between them)

                //Get all obstacles
                obstacles.AddRange(GameObject.FindGameObjectsWithTag("Obstacle"));
				obstacles.AddRange(GameObject.FindGameObjectsWithTag("corner"));

                //Get vectors FROM obstacles TO agent  
                /*foreach (GameObject obj in obstacles)
                {
					Vector2 newVector = new Vector2(this.transform.position.x - obj.transform.position.x, this.transform.position.y - obj.transform.position.y);

                    //Invert magnitudes of obstacles (further distance means lower priority avoidance)
                    //23 is maximum distance within game world (from one corner to diagonal corner)
                    float magnitude = newVector.magnitude;
                    
                    magnitude = 23-magnitude;
                    //Scale magnuitudes to be 1/5 of those of the infected 
                    //(avoiding obstacles is lower priority than avoiding the infected)


						newVector.Normalize();
						newVector *= 1f*magnitude;



	                avoidVectors.Add(newVector);


                }*/

                //Sum vectors to get an overall movement vector
                Vector2 resultantVector = new Vector2();

                foreach (Vector2 vec in avoidVectors)
                {
                    resultantVector += vec;
                }

                //Set forward vector to a Lerp between current forward vector and new vector
                transform.up = Vector3.Slerp(transform.up, new Vector3(resultantVector.x, resultantVector.y, 0), rotationLerpScale);
            }

            if (this.GetComponent<AgentManager>().infected == true)
            {
                //If infected
                ArrayList targets = new ArrayList();
                ArrayList obstacles = new ArrayList();
                ArrayList avoidVectors = new ArrayList();
                Vector2 closestTarget = new Vector2(1000.0f, 1000.0f);

                //Conner's new code//Avoid things that ARE blueberries with highest priority
                //Get all enemies & Add each infected to a list of infected
                targets.AddRange(GameObject.FindGameObjectsWithTag("AI"));

                //Get all players & Add each infected to a list of infected
                targets.AddRange(GameObject.FindGameObjectsWithTag("Player"));

                //Remove all infected targets from possible targets
                //Add all uninfected targets to list of vectors FROM agent TO target
                foreach (GameObject obj in targets)
                {
                    if (obj.GetComponent<AgentManager>().infected != true && obj.GetComponent<AgentManager>().invis == false)
                    {
                        Vector2 newVec = new Vector2(obj.transform.position.x - this.transform.position.x,
                                                     obj.transform.position.y - this.transform.position.y);
                        avoidVectors.Add(newVec);

                        //Keep track of nearest target
                        if (newVec.magnitude < closestTarget.magnitude)
                        {
                            closestTarget = newVec;
                        }
                    }
                }
                
                //Select only the nearest target
                avoidVectors.Clear();
                avoidVectors.Add(closestTarget);

                //Also avoid obstacles, proportional to how close they are. 
                //(Inversely proportional to the magnitude of the vector between them)

                //Get all obstacles
                obstacles.AddRange(GameObject.FindGameObjectsWithTag("Obstacle"));

                //Get vectors FROM obstacles TO agent  
                foreach (GameObject obj in obstacles)
                {
                    Vector2 newVector = new Vector2(obj.transform.position.x, obj.transform.position.y);

                    //Invert magnitudes of obstacles (further distance means lower priority avoidance)
                    //23 is maximum distance within game world (from one corner to diagonal corner)
                    float magnitude = newVector.magnitude;
                    newVector.Normalize();
                    newVector *= (23 - magnitude);
                    //Scale magnuitudes to be 1/5 of those of the infected 
                    //(avoiding obstacles is lower priority than avoiding the infected)
                    newVector *= (1 / 5);

                    avoidVectors.Add(newVector);
                }

                //Sum vectors to get an overall movement vector
                Vector2 resultantVector = new Vector2();

                foreach (Vector2 vec in avoidVectors)
                {
                    resultantVector += vec;
                }

                //Set forward vector to a Lerp between current forward vector and new vector
                transform.up = Vector3.Slerp(transform.up, new Vector3(resultantVector.x, resultantVector.y, 0), rotationLerpScale);
            }

            //Move towards the player's position.
            this.transform.position += this.transform.up * this.GetComponent<AgentManager>().currentSpeed * Time.deltaTime;
        }
    }
}