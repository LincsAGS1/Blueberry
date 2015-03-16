﻿using UnityEngine;
using System.Collections;

public class BedroomGenerator : MonoBehaviour 
{
    public GameObject bed;
    public GameObject bedsideTable;
    public GameObject bin;
    public GameObject deskArea;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    public GameObject player1;
    public GameObject player2;

    public GameObject locationChecker;

    // Use this for initialization
	void Start () 
    {
        float bedsideTableOffset = 3.5f;
        float binOffset = 2.0f;
        
        //select a side for the bed
        int bedSide = Random.Range(0, 4);
        int deskSide = Random.Range(0, 4);
        
        //if bed side is top/bottom
        if (bedSide == 0 || bedSide == 2)
        {
            //generate a position along that side (within limits of bed fitting)
            float centralPosition = Random.Range(-5.15f, 5.15f);
            
            //place table on whatever side has room for it (prefer left)
            if (bedSide == 0)
            {
                bed.transform.position = new Vector3(centralPosition, 2.15f, 0);
                bed.transform.eulerAngles = new Vector3(0, 0, 0);
                //Extra 1 for 1/2 width of table
                if (centralPosition + bedsideTableOffset + 1 < 8)
                { bedsideTable.transform.position = new Vector3((centralPosition + bedsideTableOffset), 4, 0); }
                else
                { bedsideTable.transform.position = new Vector3((centralPosition - bedsideTableOffset), 4, 0); }
            }
            else
            {
                bed.transform.position = new Vector3(centralPosition, -2.15f, 0);
                bed.transform.eulerAngles = new Vector3(0, 0, 180);
                if (centralPosition - bedsideTableOffset - 1 > -8)
                { bedsideTable.transform.position = new Vector3((centralPosition - bedsideTableOffset), -4, 0); }
                else
                { bedsideTable.transform.position = new Vector3((centralPosition + bedsideTableOffset), -4, 0); }
            }
        }
        else
        {
            //generate a position along that side (within limits of bed fitting)
            float centralPosition = Random.Range(-5.15f, 5.15f);

            //place table on whatever side has room for it (prefer left)
            if (bedSide == 1)
            {
                bed.transform.position = new Vector3(5.15f, centralPosition, 0);
                bed.transform.eulerAngles = new Vector3(0, 0, 90);
                if (centralPosition + bedsideTableOffset + 1 < 5)
                { bedsideTable.transform.position = new Vector3(7, (centralPosition + bedsideTableOffset), 0); }
                else
                { bedsideTable.transform.position = new Vector3(7, (centralPosition - bedsideTableOffset), 0); }
            }
            else
            {
                bed.transform.position = new Vector3(-5.15f, centralPosition, 0);
                bed.transform.eulerAngles = new Vector3(0, 0, 270);
                if (centralPosition - bedsideTableOffset - 1 > -5)
                { bedsideTable.transform.position = new Vector3(-7, (centralPosition - bedsideTableOffset), 0); }
                else
                { bedsideTable.transform.position = new Vector3(-7, (centralPosition + bedsideTableOffset), 0); }
            }
        }

        //select a DIFFERENT side for the desk
        while (bedSide == deskSide)
        {
            deskSide = Random.Range(0, 4);    
        }

        if (deskSide == 0 || deskSide == 2)
        {
            //generate a position along that side (within limits of bed fitting)
            float centralPosition = Random.Range(-6.0f, 6.0f);

            //place table on whatever side has room for it (prefer left)
            if (deskSide == 0)
            {
                deskArea.transform.position = new Vector3(centralPosition, 4, 0);
                deskArea.transform.eulerAngles = new Vector3(0, 0, 0);
                //Extra 0.5 for radius of bin
                if (centralPosition + binOffset + 0.5 < 8)
                { bin.transform.position = new Vector3((centralPosition + binOffset), 4.5f, 0); }
                else
                { bin.transform.position = new Vector3((centralPosition - binOffset), 4.5f, 0); }
            }
            else
            {
                deskArea.transform.position = new Vector3(centralPosition, -4, 0);
                deskArea.transform.eulerAngles = new Vector3(0, 0, 180);
                if (centralPosition - binOffset - 0.5 > -8)
                { bin.transform.position = new Vector3((centralPosition - binOffset), -4.5f, 0); }
                else
                { bin.transform.position = new Vector3((centralPosition + binOffset), -4.5f, 0); }
            }
        }
        else
        {
            //generate a position along that side (within limits of bed fitting)
            float centralPosition = Random.Range(-3.0f, 3.0f);

            //place table on whatever side has room for it (prefer left)
            if (deskSide == 1)
            {
                deskArea.transform.position = new Vector3(7, centralPosition, 0);
                deskArea.transform.eulerAngles = new Vector3(0, 0, 270);
                if (centralPosition + bedsideTableOffset + 1 < 5)
                { bin.transform.position = new Vector3(7.5f, (centralPosition + bedsideTableOffset), 0); }
                else
                { bin.transform.position = new Vector3(7.5f, (centralPosition - bedsideTableOffset), 0); }
            }
            else
            {
                deskArea.transform.position = new Vector3(-7, centralPosition, 0);
                deskArea.transform.eulerAngles = new Vector3(0, 0, 90);
                if (centralPosition - bedsideTableOffset - 1 > -5)
                { bin.transform.position = new Vector3(-7.5f, (centralPosition - bedsideTableOffset), 0); }
                else
                { bin.transform.position = new Vector3(-7.5f, (centralPosition + bedsideTableOffset), 0); }
            }
        }

        bool player1Pos = false;
        //generate random position for player, face center of room.
        while (player1Pos == false)
        {
            Vector2 playerPos = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            locationChecker.transform.position = new Vector3(playerPos.x, playerPos.y, 0);
            Collider2D locationCollider = locationChecker.GetComponent<Collider2D>();

            //if no obstacles within circle around that point, we've found the player's position
            if (!locationCollider.IsTouchingLayers())
            {
                //move the player there
                player1.transform.position = new Vector3(playerPos.x, playerPos.y, 0);
                locationChecker.transform.position = new Vector3(14, 0, 0);
                player1Pos = true;

                //rotate the player towards the middle
                Vector3 centerVector = -1 * player1.transform.position;
                player1.transform.up = centerVector;
            }
        }
        
        
        //generate random position for player 2 (IF PRESENT) facing centre of room
        /*if (player2present)
        {
            bool player2Pos = false;
            while (player2Pos == false)
            {
                Vector2 playerPos = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
                locationChecker.transform.position = new Vector3(playerPos.x, playerPos.y, 0);
                Collider2D locationCollider = locationChecker.GetComponent<Collider2D>();

                //if no obstacles within circle around that point, we've found the player's position
                if (!locationCollider.IsTouchingLayers())
                {
                    //move the player there
                    player2.transform.position = new Vector3(playerPos.x, playerPos.y, 0);
                    locationChecker.transform.position = new Vector3(14, 0, 0);
                    player2Pos = true;

                    //rotate the player towards the middle
                    Vector3 centerVector = -1 * player2.transform.position;
                    player2.transform.up = centerVector;
                }
            }
        }*/

        //generate random positions & rotations for the AI
        bool AIpos = false;

        //player 1
        while (!AIpos)
        {
            Vector2 randomPos = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            locationChecker.transform.position = new Vector3(randomPos.x, randomPos.y, 0);
            Collider2D locationCollider = locationChecker.GetComponent<Collider2D>();

            //if no obstacles within circle around that point, we've found the player's position
            if (!locationCollider.IsTouchingLayers())
            {
                //move the there
                enemy1.transform.position = new Vector3(randomPos.x, randomPos.y, 0);
                locationChecker.transform.position = new Vector3(14, 0, 0);
                AIpos = true;

                //rotate the towards the middle
                Vector3 centerVector = -1 * enemy1.transform.position;
                enemy1.transform.up = centerVector;
            }
        }
        AIpos = false;

        //player 2
        while (!AIpos)
        {
            Vector2 randomPos = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            locationChecker.transform.position = new Vector3(randomPos.x, randomPos.y, 0);
            Collider2D locationCollider = locationChecker.GetComponent<Collider2D>();

            //if no obstacles within circle around that point, we've found the player's position
            if (!locationCollider.IsTouchingLayers())
            {
                //move the there
                enemy2.transform.position = new Vector3(randomPos.x, randomPos.y, 0);
                locationChecker.transform.position = new Vector3(14, 0, 0);
                AIpos = true;

                //rotate the towards the middle
                Vector3 centerVector = -1 * enemy2.transform.position;
                enemy1.transform.up = centerVector;
            }
        }
        AIpos = false;
        
        //player 3
        while (!AIpos)
        {
            Vector2 randomPos = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            locationChecker.transform.position = new Vector3(randomPos.x, randomPos.y, 0);
            Collider2D locationCollider = locationChecker.GetComponent<Collider2D>();

            //if no obstacles within circle around that point, we've found the player's position
            if (!locationCollider.IsTouchingLayers())
            {
                //move the there
                enemy2.transform.position = new Vector3(randomPos.x, randomPos.y, 0);
                locationChecker.transform.position = new Vector3(14, 0, 0);
                AIpos = true;

                //rotate the towards the middle
                Vector3 centerVector = -1 * enemy3.transform.position;
                enemy3.transform.up = centerVector;
            }
        }
        AIpos = false;

        //player 4
        while (!AIpos)
        {
            Vector2 randomPos = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            locationChecker.transform.position = new Vector3(randomPos.x, randomPos.y, 0);
            Collider2D locationCollider = locationChecker.GetComponent<Collider2D>();

            //if no obstacles within circle around that point, we've found the player's position
            if (!locationCollider.IsTouchingLayers())
            {
                //move the there
                enemy2.transform.position = new Vector3(randomPos.x, randomPos.y, 0);
                locationChecker.transform.position = new Vector3(14, 0, 0);
                AIpos = true;

                //rotate the towards the middle
                Vector3 centerVector = -1 * enemy4.transform.position;
                enemy4.transform.up = centerVector;
            }
        }
        AIpos = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}