using UnityEngine;
using System.Collections;

public class DelayWait : MonoBehaviour 
{

	public int secWait = 3;
	public int[] totalSec = new int[3];
	// Use this for initialization
	void Start () 
	{
	


	}

	void TimerInvoke()

	{

		if (totalSec [0] < secWait)
			totalSec [0]++;

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
