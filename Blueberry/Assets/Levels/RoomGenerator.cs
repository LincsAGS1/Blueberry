using UnityEngine;
using System.Collections;

namespace Assets.Scripts.LevelGenerators
{
    class RoomGenerator : MonoBehaviour
    {
        #region Declarations
        public GameObject[] objects;
        public bool[] nearWall;
        public bool[] randomRot;

        public GameObject[] enemies;
        
        public GameObject player1;
        public GameObject player2;
        #endregion
        
        // Use this for initialization
        void Start()
        {
            int mask = 1 << 8;
            mask = ~mask;

            //Object Positioning
            Debug.Log("Object Positioning Begin");
            for (int i = 0; i < objects.Length; i++)
            {
                if (nearWall[i])
                { PositionObjectByWall(objects[i]); }
                else
                { PositionObject(objects[i]); }

                if (randomRot[i])
                { objects[i].transform.up = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0); }
            }
            Debug.Log("Object Positions Done");
            
            #region Player Positioning
            bool player1Pos = false;
            //generate random position for player, face center of room.
            Debug.Log("Player 1 Position Begin");
            while (player1Pos == false)
            {
                Vector2 playerPos = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));

                //get all colliders in that region
                Collider2D[] collisions = Physics2D.OverlapCircleAll(playerPos, 0.5f, mask);

                //if no obstacles within circle around that point, we've found the player's position
                if (collisions.Length == 0)
                {
                    //move the player there
                    player1.transform.position = new Vector3(playerPos.x, playerPos.y, 0);
                    player1Pos = true;

                    //rotate the player towards the middle
                    Vector3 centerVector = -1 * player1.transform.position;
                    player1.transform.up = centerVector;
                }
            }
            Debug.Log("Player 1 Position Done");


            //generate random position for player 2 (IF PRESENT) facing centre of room
            /*if (player2present)
            {*/
                bool player2Pos = false;
            //generate random position for player, face center of room.
            Debug.Log("Player 2 Position Begin");
            while (player2Pos == false)
            {
                Vector2 playerPos = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));

                //get all colliders in that region
                Collider2D[] collisions = Physics2D.OverlapCircleAll(playerPos, 0.5f, mask);

                //if no obstacles within circle around that point, we've found the player's position
                if (collisions.Length == 0)
                {
                    //move the player there
                    player2.transform.position = new Vector3(playerPos.x, playerPos.y, 0);
                    player2Pos = true;

                    //rotate the player towards the middle
                    Vector3 centerVector = -1 * player1.transform.position;
                    player2.transform.up = centerVector;
                }
            }
        
            #endregion


            //Enemy Positioning
            Debug.Log("Enemy Positions Begin");
            for (int i = 0; i < enemies.Length; i++)
            {
                //generate random positions & rotations for the AI
                bool AIpos = false;

                while (!AIpos)
                {
                    Vector2 randomPos = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));

                    //get all colliders in that region
                    Collider2D[] collisions = Physics2D.OverlapCircleAll(randomPos, 0.5f, mask);

                    //if no obstacles within circle around that point, we've found the player's position
                    if (collisions.Length == 0)
                    {
                        //move the there
                        enemies[i].transform.position = new Vector3(randomPos.x, randomPos.y, 0);
                        AIpos = true;

                        //rotate the towards the middle
                        Vector3 centerVector = -1 * enemies[i].transform.position;
                        enemies[i].transform.up = centerVector;
                    }
                }
            }
            Debug.Log("Enemy Positions Done");
        }

        private void PositionObject(GameObject obj)
        {
            bool posFound = false;
            int mask = 1 << 8;
            mask = ~mask;

            while (!posFound)
            {
                Vector2 randomPos = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
                Collider2D[] collisions;
                
                //get all colliders in that region
                if ( obj.GetComponent<SpriteRenderer>().bounds.extents.x >
                     obj.GetComponent<SpriteRenderer>().bounds.extents.y)
                { collisions = Physics2D.OverlapCircleAll(randomPos, obj.GetComponent<SpriteRenderer>().bounds.extents.x, mask); } 
                else
                { collisions = Physics2D.OverlapCircleAll(randomPos, obj.GetComponent<SpriteRenderer>().bounds.extents.y, mask); }

                if (collisions.Length == 0)
                {
                    obj.transform.position = new Vector3(randomPos.x, randomPos.y, 0);
                    posFound = true;
                }
            }
        }

        private void PositionObjectByWall(GameObject obj)
        {
            bool posFound = false;
            int mask = 1 << 8;
            mask = ~mask;

            while (!posFound)
            {
                Vector2 newPos = new Vector2(   Random.Range(-8 + obj.GetComponent<Collider2D>().bounds.extents.x, 8 - obj.GetComponent<Collider2D>().bounds.extents.x),
                                                Random.Range(-5 + obj.GetComponent<Collider2D>().bounds.extents.y, 5 * obj.GetComponent<Collider2D>().bounds.extents.y));
                Collider2D[] collisions;
                int wall = 0;

                //Select the nearest wall, and use the position on that wall
                if (Mathf.Abs(newPos.x)/8 > Mathf.Abs(newPos.y)/5)
                {
                    if (newPos.x >= 0)  { wall = 1; }
                    else                { wall = 3; }
                }
                else
                {
                    if (newPos.y >= 0)  { wall = 0; }
                    else                { wall = 2; }
                }

                //Adjust the position to be close to the wall              
                switch (wall)
                {
                    case 0: obj.transform.eulerAngles = new Vector3(0, 0, 0); 
                            newPos = new Vector2(newPos.x, 4.9f - obj.GetComponent<Collider2D>().bounds.extents.y);
                            break;
                    case 1: obj.transform.eulerAngles = new Vector3(0, 0, 270); 
                            newPos = new Vector2(7.9f - obj.GetComponent<Collider2D>().bounds.extents.x, newPos.y); 
                            break;
                    case 2: obj.transform.eulerAngles = new Vector3(0, 0, 180); 
                            newPos = new Vector2(newPos.x, -4.9f + obj.GetComponent<Collider2D>().bounds.extents.y); 
                            break;
                    case 3: obj.transform.eulerAngles = new Vector3(0, 0, 90); 
                            newPos = new Vector2(-7.9f + obj.GetComponent<Collider2D>().bounds.extents.x, newPos.y); 
                            break;
                }
                
                //if that's a valid position, move the object there
                //get all colliders in that region (use OverlapCircle all for Circle Colliders, or OverlapAreaAll for anything else
                if (this.GetComponent<CircleCollider2D>() == null)
                { collisions = Physics2D.OverlapCircleAll(newPos, obj.GetComponent<SpriteRenderer>().bounds.extents.y, mask); }
                else
                {
                    if (wall == 0 || wall == 2)
                    {
                        Vector2 topLeft =       new Vector2(newPos.x - obj.GetComponent<Collider2D>().bounds.extents.x, newPos.y + obj.GetComponent<Collider2D>().bounds.extents.y);
                        Vector2 bottomRight =   new Vector2(newPos.x + obj.GetComponent<Collider2D>().bounds.extents.x, newPos.y - obj.GetComponent<Collider2D>().bounds.extents.y);
                        collisions = Physics2D.OverlapAreaAll(topLeft, bottomRight, mask);
                    }
                    else
                    {
                        Vector2 topLeft =       new Vector2(newPos.x - obj.GetComponent<Collider2D>().bounds.extents.y, newPos.y + obj.GetComponent<Collider2D>().bounds.extents.x);
                        Vector2 bottomRight =   new Vector2(newPos.x + obj.GetComponent<Collider2D>().bounds.extents.y, newPos.y - obj.GetComponent<Collider2D>().bounds.extents.x);
                        collisions = Physics2D.OverlapAreaAll(topLeft, bottomRight, mask);
                    }
                }

                //So long as there's no collisions, move the object there.
                if (collisions.Length == 0)
                {
                    Debug.Log(obj.name + " placed at " + newPos.x + ", " + newPos.y);
                    obj.transform.localPosition = new Vector3(newPos.x, newPos.y, 0);
                    posFound = true;
                }
                else
                {
                    string debugString = newPos.x + ", " +  newPos.y + " Rejected for " + obj.name + " because of collisions with: ";

                    for (int i = 0; i < collisions.Length; i++)
                    {
                        if (i != (collisions.Length - 1))
                        { debugString += (collisions[i].gameObject.name + " & "); }
                        else
                        { debugString += collisions[i].gameObject.name; }
                    }

                    Debug.Log(debugString); 
                }
            }
        }
    }
}
