using System.Collections.Generic;
using UnityEngine;

public class Enemy0Move : MonoBehaviour
{
    public Board BoardManager;
    public float MoveDelay;
    private bool MoveEnabled = true;
    private Animator AnimatorComponent;
    private int Direction = 0;

    private void Start()
    {
        BoardManager = GameObject.FindGameObjectWithTag("BoardManager").GetComponent<Board>();
        AnimatorComponent = GetComponent<Animator>();
        Direction = Random.Range(1, 5);

        if (Direction == 2)
        {
            AnimatorComponent.SetTrigger("Flip");
        }
    }

    private void Update()
    {
        if (MoveEnabled)
        {
            Vector2 movementDirection = Vector2.zero;

            switch (Direction)
            {
                case 1:
                    movementDirection = new Vector2(0, 1);
                    break;
                case 2:
                    movementDirection = new Vector2(1, 0);
                    break;
                case 3:
                    movementDirection = new Vector2(0, -1);
                    break;
                case 4:
                    movementDirection = new Vector2(-1, 0);
                    break;
            }

            if (movementDirection != Vector2.zero)
            {
                MoveEnabled = false;
                Invoke("EnableMovement", MoveDelay);
                Vector2 newPos = transform.position;
                newPos.x += movementDirection.x;
                newPos.y += movementDirection.y;
                newPos = BoardManager.WorldToBoard(newPos);

                if (BoardManager.ValidPosition((int)newPos.x, (int)newPos.y))
                {
                    transform.Translate(movementDirection);
                }
                else
                {
                    List<int> validDirections = new List<int>();
                    newPos = new Vector2(transform.position.x, transform.position.y + 1);
                    newPos = BoardManager.WorldToBoard(newPos);
                    if (BoardManager.ValidPosition((int)newPos.x, (int)newPos.y))
                    {
                        validDirections.Add(1);
                    }
                    newPos = new Vector2(transform.position.x + 1, transform.position.y);
                    newPos = BoardManager.WorldToBoard(newPos);
                    if (BoardManager.ValidPosition((int)newPos.x, (int)newPos.y))
                    {
                        validDirections.Add(2);
                    }
                    newPos = new Vector2(transform.position.x, transform.position.y - 1);
                    newPos = BoardManager.WorldToBoard(newPos);
                    if (BoardManager.ValidPosition((int)newPos.x, (int)newPos.y))
                    {
                        validDirections.Add(3);
                    }
                    newPos = new Vector2(transform.position.x - 1, transform.position.y);
                    newPos = BoardManager.WorldToBoard(newPos);
                    if (BoardManager.ValidPosition((int)newPos.x, (int)newPos.y))
                    {
                        validDirections.Add(4);
                    }

                    int choice = Random.Range(0, validDirections.Count);

                    if (((Direction == 4) && (validDirections[choice] == 2)) || ((Direction == 2) && (validDirections[choice] == 4)))
                    {
                        AnimatorComponent.SetTrigger("Flip");
                    }

                    Direction = validDirections[choice];
                }
            }
        }
    }

    private void EnableMovement()
    {
        MoveEnabled = true;
    }
}
