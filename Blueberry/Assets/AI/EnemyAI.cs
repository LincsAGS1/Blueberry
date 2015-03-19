using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
    public int moveSpeed;
	public float rotationLerpScale;
    public bool canMove = true;

    //public Transform target;
    //public float rotationSpeed;
	//float distance;
    //private Transform myTransform;
    //public int maxDistance;
    //public int alertDistance;
    //public GameObject go;	
	//int alertDistance = 11;
	//int alertDistance = 14;
    
	void Awake() 
    {
		//myTransform = transform;
	}
	
	// Use this for initialization
	void Start () 
    {
		//go = GameObject.FindGameObjectWithTag("Player");
		//target = go.transform;
		//Find the player and get their position. Will need to be made more advanced later as other people may get the virus.
	}
	
	// Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            //Debug.DrawLine(target.position, this.transform.position, Color.yellow);
            //distance = Vector3.Distance(target.position, myTransform.position);

            if (this.GetComponent<CollisionManager>().infected == false)
            {
                //If NOT a carrier
                ArrayList infected = new ArrayList();
                ArrayList obstacles = new ArrayList();
                ArrayList avoidVectors = new ArrayList();

                //Conner's new code
                //Avoid things that ARE blueberries with highest priority
                    //Get all enemies & Add each infected to a list of infected
                    infected.AddRange(GameObject.FindGameObjectsWithTag("AI"));
                        
                    //Get all players & Add each infected to a list of infected
                    infected.AddRange(GameObject.FindGameObjectsWithTag("Player"));
                    
                    //Get vectors FROM infected TO agent & add to list of vectors
                    //Vector = Destination - Origin
                    foreach(GameObject obj in infected)
                    {
                        avoidVectors.Add(new Vector2(this.transform.position.x - obj.transform.position.x,
                                                     this.transform.position.y - obj.transform.position.y));
                    }
                                        
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
                    newVector *= (1/5);

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

                //Connor's Old Code

                /*if (Vector3.Distance(target.position, myTransform.position) < alertDistance)
                 *{
                 *    //If the AI is close enough to notice the player. Will be used for selecting of who to chase after, when that feature is implemented.
                 *    //This ensure the AI locks onto the player and moves towards him correctly.
                 *    bool needsWeirdAngThing = Vector3.Angle(Vector3.right, target.position - this.transform.position) > 90;
                 *    transform.rotation = Quaternion.Lerp(myTransform.rotation, Quaternion.RotateTowards(myTransform.rotation, Quaternion.LookRotation(target.position - transform.position), 90), rotationSpeed);
                 *    //transform.LookAt(target.position);
                 *    transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, 90, 270);
                 *
                 *    if (needsWeirdAngThing == true)
                 *        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 270, 90);
                 *    else
                 *        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, 270);
                 *} */
            }

            if (this.GetComponent<CollisionManager>().infected == true)
            {
                //If infected
                ArrayList targets = new ArrayList();
                ArrayList obstacles = new ArrayList();
                ArrayList avoidVectors = new ArrayList();
                Vector2 closestTarget = new Vector2(1000.0f,1000.0f);

                //Conner's new code//Avoid things that ARE blueberries with highest priority
                //Get all enemies & Add each infected to a list of infected
                targets.AddRange(GameObject.FindGameObjectsWithTag("AI"));

                //Get all players & Add each infected to a list of infected
                targets.AddRange(GameObject.FindGameObjectsWithTag("Player"));

                //Remove all infected targets from possible targets
                //Add all uninfected targets to list of vectors FROM agent TO target
                foreach (GameObject obj in targets)
                {
                    if (obj.GetComponent<CollisionManager>().infected != true)
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

                //Connor's old code
                //Problem was with using quaternions for rotation - Doesn't work in 2D
                /*if (Vector3.Distance(target.position, myTransform.position) < alertDistance)
                 *{
                 *    //If the AI is close enough to notice the player. Will be used for selecting of who to chase after, when that feature is implemented.
                 *    //This ensure the AI locks onto the player and moves towards him correctly.
                 *    bool needsWeirdAngThing = Vector3.Angle(Vector3.right, target.position - this.transform.position) > 90;
                 *    transform.rotation = Quaternion.Lerp(myTransform.rotation, Quaternion.RotateTowards(myTransform.rotation, Quaternion.LookRotation(target.position - transform.position), 90), rotationSpeed);
                 *    //transform.LookAt(target.position);
                 *    transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, 90, 270);
                 *
                 *    if (needsWeirdAngThing == true)
                 *        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 270, 90);
                 *    else
                 *        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, 270);
                 *
                 *    transform.Rotate(0, 180, 0);
                 *}*/
            }

            //Move towards the player's position.
            this.transform.position += this.transform.up * moveSpeed * Time.deltaTime;
        }
    }
}