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
            //Object Positioning
            for (int i = 0; i < objects.Length; i++)
            {
                if (nearWall[i])
                { PositionObject(objects[i]); }
                else
                { PositionObjectByWall(objects[i]); }

                if (randomRot[i])
                { objects[i].transform.up = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0); }
            }
            
            #region Player Positioning
            bool player1Pos = false;
            //generate random position for player, face center of room.
            while (player1Pos == false)
            {
                Vector2 playerPos = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));

                //get all colliders in that region
                Collider2D[] collisions = Physics2D.OverlapCircleAll(playerPos, 0.5f);

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


            //generate random position for player 2 (IF PRESENT) facing centre of room
            /*if (player2present)
            {
                bool player2Pos = false;
                while (player2Pos == false)
                {
                    Vector2 playerPos = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));

                    //if no obstacles within circle around that point, we've found the player's position
                    if (!locationCollider.IsTouchingLayers())
                    {
                        //move the player there
                        player2.transform.position = new Vector3(playerPos.x, playerPos.y, 0);
                        player2Pos = true;

                        //rotate the player towards the middle
                        Vector3 centerVector = -1 * player2.transform.position;
                        player2.transform.up = centerVector;
                    }
                }
            }*/
            #endregion

            //Enemy Positioning
            for (int i = 0; i < enemies.Length; i++)
            {
                //generate random positions & rotations for the AI
                bool AIpos = false;

                while (!AIpos)
                {
                    Vector2 randomPos = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));

                    //get all colliders in that region
                    Collider2D[] collisions = Physics2D.OverlapCircleAll(randomPos, 0.5f);

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
        }

        private void PositionObject(GameObject obj)
        {
            bool posFound = false;

            while (!posFound)
            {
                Vector2 randomPos = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
                Collider2D[] collisions;

                //get all colliders in that region
                if ( obj.GetComponent<SpriteRenderer>().bounds.extents.x >
                     obj.GetComponent<SpriteRenderer>().bounds.extents.y)
                { collisions = Physics2D.OverlapCircleAll(randomPos, obj.GetComponent<SpriteRenderer>().bounds.extents.x); } 
                else
                { collisions = Physics2D.OverlapCircleAll(randomPos, obj.GetComponent<SpriteRenderer>().bounds.extents.y); }

                if (collisions.Length == 0)
                {
                    obj.transform.position = new Vector3(randomPos.x, randomPos.y, 0);
                }
            }
        }

        private void PositionObjectByWall(GameObject obj)
        {
            bool posFound = false;

            while (!posFound)
            {
                Vector2 newPos = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
                float[] wallDistance = new float[4];
                Collider2D[] collisions;
                int wall = 0;

                //Select the nearest wall, and use the position on that wall
                wallDistance[0] = 5 - newPos.y;
                wallDistance[1] = 8 - newPos.x;
                wallDistance[2] = -5 - newPos.y;
                wallDistance[3] = -8 - newPos.x;

                //Adjust the position to be close to the wall
                for (int i = 0; i < 4; i++)
                {
                    if (wallDistance[i] < wallDistance[wall])
                    { wall = i; }
                }

                switch (wall)
                {
                    case 0: if (obj.GetComponent<SpriteRenderer>().bounds.extents.x >
                                obj.GetComponent<SpriteRenderer>().bounds.extents.y)
                        { newPos = new Vector2(8 - obj.GetComponent<SpriteRenderer>().bounds.extents.x, newPos.y); }
                        else
                        { newPos = new Vector2(8 - obj.GetComponent<SpriteRenderer>().bounds.extents.y, newPos.y); }

                        obj.transform.eulerAngles = new Vector3(0, 0, 0);
                        break;
                    case 1: if (obj.GetComponent<SpriteRenderer>().bounds.extents.x >
                                obj.GetComponent<SpriteRenderer>().bounds.extents.y)
                        { newPos = new Vector2(newPos.x, 5 - obj.GetComponent<SpriteRenderer>().bounds.extents.x); }
                        else
                        { newPos = new Vector2(newPos.x, 5 - obj.GetComponent<SpriteRenderer>().bounds.extents.y); }
                        
                        obj.transform.eulerAngles = new Vector3(0, 0, 0);
                        break;
                    case 2: if (obj.GetComponent<SpriteRenderer>().bounds.extents.x >
                                 obj.GetComponent<SpriteRenderer>().bounds.extents.y)
                        { newPos = new Vector2(-8 + obj.GetComponent<SpriteRenderer>().bounds.extents.x, newPos.y); }
                        else
                        { newPos = new Vector2(-8 + obj.GetComponent<SpriteRenderer>().bounds.extents.y, newPos.y); }
                        
                        obj.transform.eulerAngles = new Vector3(0, 0, 0);
                        break;
                    case 3: if (obj.GetComponent<SpriteRenderer>().bounds.extents.x >
                                 obj.GetComponent<SpriteRenderer>().bounds.extents.y)
                        { newPos = new Vector2(newPos.x, -5 + obj.GetComponent<SpriteRenderer>().bounds.extents.x); }
                        else
                        { newPos = new Vector2(newPos.x, -5 + obj.GetComponent<SpriteRenderer>().bounds.extents.y); }
                        
                        obj.transform.eulerAngles = new Vector3(0, 0, 0);
                        break;
                }

                //if that's a valid position, move the object there
                //get all colliders in that region
                if (obj.GetComponent<SpriteRenderer>().bounds.extents.x >
                     obj.GetComponent<SpriteRenderer>().bounds.extents.y)
                { collisions = Physics2D.OverlapCircleAll(newPos, obj.GetComponent<SpriteRenderer>().bounds.extents.x); }
                else
                { collisions = Physics2D.OverlapCircleAll(newPos, obj.GetComponent<SpriteRenderer>().bounds.extents.y); }

                //So long as there's no collisions, move the object there.
                if (collisions.Length == 0)
                {
                    obj.transform.position = new Vector3(newPos.x, newPos.y, 0); 
                }
            }
        }
    }
}
