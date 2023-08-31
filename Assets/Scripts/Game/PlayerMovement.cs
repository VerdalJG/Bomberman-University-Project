using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables for powerups
    static public int fireNumber = 2;
    private int speed = 5;
    static public int maxBombCount = 1;
    static public int currentBombCount = 0;

    //Limits to powerup levels
    private int minMinBombCount = 1;
    private int maxMaxBombCount = 10;
    private int minMinFireCount = 2;
    private int maxMaxFireCount = 15;

    //Reference to Rigidbody and Animator
    private Rigidbody2D playerRB;
    private Animator playerAnim;

    public float playerHorizontal;
    public float playerVertical;
    public Vector2 playerVelocity;
    [SerializeField] private GameObject WinText;
    Vector3 CenterPosition = new Vector3(13, 7, 0);

    private float playerDirection = 0;

    private bool gameActive = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            // WASD to control variables
            playerHorizontal = Input.GetAxisRaw("HorizontalP1");
            playerVertical = Input.GetAxisRaw("VerticalP1");
            //Convert Input into vector
            Vector2 playerInput = new Vector2(playerHorizontal, playerVertical);
            //Multiply vector by speed to get velocity
            playerVelocity = playerInput.normalized * speed;
            //Move player according to velocity
            playerRB.MovePosition(playerRB.position + playerVelocity * Time.fixedDeltaTime);
            if (playerHorizontal == 1 & playerVertical == 0)
            {
                playerDirection = 2;
            }
            else if (playerHorizontal == -1 & playerVertical == 0)
            {
                playerDirection = 4;
            }

            if (playerVertical == 1 & playerHorizontal == 0)
            {
                playerDirection = 1;
            }
            else if (playerVertical == -1 & playerHorizontal == 0)
            {
                playerDirection = 3;
            }

            if (playerHorizontal == 0 & playerVertical == 0)
            {
                playerDirection = 0;
            }
        }

        //Powerup Level control using limits
        if (fireNumber > maxMaxFireCount)
        {
            fireNumber = maxMaxFireCount;
        }
        if (fireNumber < minMinFireCount)
        {
            fireNumber = minMinFireCount;
        }
        if (maxBombCount > maxMaxBombCount)
        {
            maxBombCount = maxMaxBombCount;
        }
        if (maxBombCount < minMinBombCount)
        {
            maxBombCount = minMinBombCount ;
        }
    }
    private void FixedUpdate()
    {
        if (playerDirection == 0)
        {
            playerAnim.SetInteger("Direction", 0);
        }
        if (playerDirection == 1)
        {
            playerAnim.SetInteger("Direction", 1);
        }
        if (playerDirection == 2)
        {
            playerAnim.SetInteger("Direction", 2);
        }
        if (playerDirection == 3)
        {
            playerAnim.SetInteger("Direction", 3);
        }
        if (playerDirection == 4)
        {
            playerAnim.SetInteger("Direction", 4);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.StartsWith("Explosion"))
        {
            playerAnim.SetBool("Alive", false);
            playerAnim.SetTrigger("Death");

            gameActive = false;
            Destroy(gameObject, 0.2f);
        }

        if (collision.tag.StartsWith("Door"))
        {
            playerAnim.SetBool("Alive", false);
            playerAnim.SetTrigger("Win");

            GameObject youWin = Instantiate(WinText, CenterPosition , Quaternion.identity);
            gameActive = false; 
        }
    }
}
