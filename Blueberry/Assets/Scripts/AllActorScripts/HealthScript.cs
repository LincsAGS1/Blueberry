using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour 
{
	public float health = 100;
	
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
		if (this.tag.Equals("Player"))
        {
            //GUI.Label (new Rect (85, 100, 100, 30),"Player Health:"); 
		    GUI.Label (new Rect (480, 30, 200, 30),"Player Health:  " +health.ToString());
        }
	}
}
