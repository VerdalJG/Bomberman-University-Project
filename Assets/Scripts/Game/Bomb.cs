using System;
using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float FuseTime = 3f;
    public GameObject ExplosionCenter;
    public GameObject ExplosionVertical;
    public GameObject ExplosionHorizontal;
    public GameObject ExplosionUp;
    public GameObject ExplosionRight;
    public GameObject ExplosionDown;
    public GameObject ExplosionLeft;
    private bool occupiedUp = false;
    private bool occupiedDown = false;
    private bool occupiedLeft = false;
    private bool occupiedRight = false;


    void Start()
    {
        Invoke("Explode", FuseTime);
    }


    private void Explode()
    {
        Board manager = GameObject.FindGameObjectWithTag("BoardManager").GetComponent<Board>();
        //Center explosion
        Instantiate(ExplosionCenter, transform.position, Quaternion.identity);


        //Create upper explosion
        for (int i = 1; i < PlayerMovement.fireNumber; i++)
        {
            if (!occupiedUp)
            {
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y + i);
                newPos = manager.WorldToBoard(newPos);
                if (manager.ValidPosition((int)newPos.x, (int)newPos.y))
                {
                    Instantiate(ExplosionVertical, new Vector2(transform.position.x, transform.position.y + i), Quaternion.identity);
                }
                else
                {
                    GameObject block = manager.GetBlockAt((int)newPos.x, (int)newPos.y);
                    if ((block != null) && (block.tag == "BlockDestructible"))
                    {
                        block.GetComponent<BlockDestructible>().BeginDestroy();
                    }
                    else if ((block != null) && (block.tag == "Enemy")) //Destroys Enemy
                    {
                        
                    }
                    if ((block != null) && (block.tag == "Block"))// Collision with solid block above
                    {
                        occupiedUp = true;
                    }
                }
            }  
        }
        //Create explosions X + 1
        for (int i = 1; i < PlayerMovement.fireNumber; i++)
        {
            Vector2 newPos = new Vector2(transform.position.x + i, transform.position.y);
            if (!occupiedRight)
            {
                newPos = manager.WorldToBoard(newPos);
                if (manager.ValidPosition((int)newPos.x, (int)newPos.y))
                {
                    Instantiate(ExplosionHorizontal, new Vector2(transform.position.x + i, transform.position.y), Quaternion.identity);
                }
                else
                {
                    GameObject block = manager.GetBlockAt((int)newPos.x, (int)newPos.y);
                    if ((block != null) && (block.tag == "BlockDestructible"))
                    {
                        block.GetComponent<BlockDestructible>().BeginDestroy();
                    }
                    else if ((block != null) && (block.tag == "Enemy")) //Destroys Enemy
                    {
                        
                    }
                    if ((block != null) && (block.tag == "Block"))// Collision with solid block to the right
                    {
                        occupiedRight = true;
                    }
                }
            }
        }
        //Create explosions Y - 1
        for (int i = 1; i < PlayerMovement.fireNumber; i++)
        {
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y - i);
            if (!occupiedDown)
            {
                newPos = manager.WorldToBoard(newPos);
                if (manager.ValidPosition((int)newPos.x, (int)newPos.y))
                {
                    Instantiate(ExplosionVertical, new Vector2(transform.position.x, transform.position.y - i), Quaternion.identity);
                }
                else
                {
                    GameObject block = manager.GetBlockAt((int)newPos.x, (int)newPos.y);
                    if ((block != null) && (block.tag == "BlockDestructible"))
                    {
                        block.GetComponent<BlockDestructible>().BeginDestroy();
                    }
                    else if ((block != null) && (block.tag == "Enemy")) //Destroys Enemy
                    {
                        
                    }
                    if ((block != null) && (block.tag == "Block"))// Collision with solid block above
                    {
                        occupiedDown = true;
                    }
                }
            }
        }
        //Create explosions X - 1
        for (int i = 1; i < PlayerMovement.fireNumber; i++)
        {
            Vector2 newPos = new Vector2(transform.position.x - i, transform.position.y);
            if (!occupiedLeft)
            {
                newPos = manager.WorldToBoard(newPos);
                if (manager.ValidPosition((int)newPos.x, (int)newPos.y))
                {
                    Instantiate(ExplosionLeft, new Vector2(transform.position.x - i, transform.position.y), Quaternion.identity);
                }
                else
                {
                    GameObject block = manager.GetBlockAt((int)newPos.x, (int)newPos.y);
                    if ((block != null) && (block.tag == "BlockDestructible"))
                    {
                        block.GetComponent<BlockDestructible>().BeginDestroy();
                    }
                    else if ((block != null) && (block.tag == "Enemy")) //Destroys Enemy
                    {
                        
                    }
                    if ((block != null) && (block.tag == "Block"))// Collision with solid block above
                    {
                        occupiedLeft = true;
                    }
                }
            }

            
        }
        Destroy(gameObject);
        PlayerMovement.currentBombCount -= 1;
    }

}