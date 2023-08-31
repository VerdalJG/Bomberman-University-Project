using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary2 : MonoBehaviour
{
    CircleCollider2D circleCollider;

    //Screen boundaries
    float ScreenLeft = -0.3f;
    float ScreenRight = 28.3f;
    float ScreenTop = 14.7f;
    float ScreenBottom = 0f;


    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StayInScreen();
    }
    void StayInScreen()
    {
        Vector3 Position = transform.position;
        if (Position.x - circleCollider.radius < ScreenLeft)
        {
            Position.x = ScreenLeft + circleCollider.radius;
        }
        if (Position.x + circleCollider.radius > ScreenRight)
        {
            Position.x = ScreenRight - circleCollider.radius;
        }
        if (Position.y + circleCollider.radius > ScreenTop)
        {
            Position.y = ScreenTop - circleCollider.radius;
        }
        if (Position.y - circleCollider.radius < ScreenBottom)
        {
            Position.y = ScreenBottom + circleCollider.radius;
        }
        transform.position = Position;


    }
    private void OnCollisionEnter2D(Collision2D playerCollision)
    {

        if (playerCollision.collider.tag.StartsWith("Block"))
        {
            Debug.Log("Collision Detected");
            //Half block size for collider reference
            float colliderBounds = 0.50f;

            float collDiffX = transform.position.x - playerCollision.gameObject.transform.position.x;
            float collDiffY = transform.position.y - playerCollision.gameObject.transform.position.y;

            Vector3 Position = transform.position;

            //X and Y positions of the sides of the blocks
            float collTop = playerCollision.gameObject.transform.position.y + colliderBounds + 0.5f;
            float collBottom = playerCollision.gameObject.transform.position.y - colliderBounds;
            float collRight = playerCollision.gameObject.transform.position.x + colliderBounds + 0.2f;
            float collLeft = playerCollision.gameObject.transform.position.x - colliderBounds - 0.3f;

            if (Mathf.Abs(collDiffX) > Mathf.Abs(collDiffY)) //HORIZONTAL COLLISION
            {
                //Check if player is coming from the left or right
                if (Position.x > playerCollision.gameObject.transform.position.x) //Player is coming from the right
                {
                    if (Position.x - circleCollider.radius < collRight)
                    {
                        Position.x = collRight + circleCollider.radius;
                    }
                }
                if (Position.x < playerCollision.gameObject.transform.position.x) //Player is coming from the left
                {
                    if (Position.x + circleCollider.radius > collLeft)
                    {
                        Position.x = collLeft - circleCollider.radius + 0.15f;
                    }
                }

            }
            else if (Mathf.Abs(collDiffX) < Mathf.Abs(collDiffY)) //VERTICAL COLLISION
            {

                //Check if player is coming from the top or bottom
                if (Position.y > playerCollision.gameObject.transform.position.y) //Player is coming from the top
                {
                    if (Position.y - circleCollider.radius < collTop)
                    {
                        Position.y = collTop + circleCollider.radius;
                    }
                }
                if (Position.y < playerCollision.gameObject.transform.position.y) //Player is coming from the bottom
                {
                    if (Position.y + circleCollider.radius > collBottom)
                    {
                        Position.y = collBottom - circleCollider.radius + 0.25f;
                    }
                }
            }
            transform.position = Position;
        }
    }
}
