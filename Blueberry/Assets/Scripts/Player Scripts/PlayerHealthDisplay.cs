using UnityEngine;
using System.Collections;

public class PlayerHealthDisplay : MonoBehaviour 
{
    //public GameObject enemy;
	
	// Use this for initialization
	void Start () 
    {
		if (newUiAiPicker.aiCount == 1)
		{
            
		}
	}
	
	// Update is called once per frame
	void Update () 
    {
		float newHealth = this.GetComponent<HealthScript>().health;

        //Optimised this by reversing order and making else if's.
        //Means that you don't have to run through all 16 if statements every single time
        if (newHealth <= 0)
        {
            transform.localScale = new Vector3(0.0F, 0.6F, 1F);
            Debug.Log(this.name + " Died");
        }
        else if (newHealth <= 2.5)
        {
            transform.localScale = new Vector3(0.15F, 0.6F, 1F);
        }
        else if (newHealth <= 5)
        {
            transform.localScale = new Vector3(0.3F, 0.6F, 1F);
        }
        else if (newHealth <= 10)
        {
            transform.localScale = new Vector3(0.6F, 0.6F, 1F);
        }
        else if (newHealth <= 15)
        {
            transform.localScale = new Vector3(0.9F, 0.6F, 1F);
        }
        else if (newHealth <= 20)
        {
            transform.localScale = new Vector3(1.2F, 0.6F, 1F);
        }
        else if (newHealth <= 25)
        {
            transform.localScale = new Vector3(1.5F, 0.6F, 1F);
        }
        else if (newHealth <= 30)
        {
            transform.localScale = new Vector3(1.8F, 0.6F, 1F);
        }
        else if (newHealth <= 35)
        {
            transform.localScale = new Vector3(2.1F, 0.6F, 1F);
        }
        else if (newHealth <= 40)
        {
            transform.localScale = new Vector3(2.4F, 0.6F, 1F);
        }
        else if (newHealth <= 45)
        {
            transform.localScale = new Vector3(2.7F, 0.6F, 1F);
        }
        else if (newHealth <= 50)
        {
            transform.localScale = new Vector3(3.0F, 0.6F, 1F);
        }
        else if (newHealth <= 55)
        {
            transform.localScale = new Vector3(3.3F, 0.6F, 1F);
        }
        else if (newHealth <= 60)
        {
            transform.localScale = new Vector3(3.6F, 0.6F, 1F);
        }
        else if (newHealth <= 65)
        {
            transform.localScale = new Vector3(3.9F, 0.6F, 1F);
        }
        else if (newHealth <= 70)
        {
            transform.localScale = new Vector3(4.2F, 0.6F, 1F);
        }
        else if (newHealth <= 75)
        {
            transform.localScale = new Vector3(4.5F, 0.6F, 1F);
        }
        else if (newHealth <= 80)
        {
            transform.localScale = new Vector3(4.8F, 0.6F, 1F);
        }
        else if (newHealth <= 85)
        {
            transform.localScale = new Vector3(5.1F, 0.6F, 1F);
        }
        else if (newHealth <= 90)
        {
            transform.localScale = new Vector3(5.4F, 0.6F, 1F);
        }
        else if (newHealth <=  95)
		{
			transform.localScale = new Vector3(5.7F, 0.6F, 1F);			
		}
    }
}
