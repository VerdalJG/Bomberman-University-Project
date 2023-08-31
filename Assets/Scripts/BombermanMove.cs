using UnityEngine;

public class BombermanMove : MonoBehaviour
{
    public float MoveDelay;
    private bool MoveEnabled = true;
    private Animator AnimatorComponent;
    private Vector2 OldDirection;

    private void Start()
    {
        AnimatorComponent = GetComponent<Animator>();
    }

    private void Update()
    {
        if (MoveEnabled)
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            Vector2 direction = Vector2.zero;

            if (vertical != 0)
            {
                MoveEnabled = false;
                Invoke("EnableMovement", MoveDelay);
                if (vertical > 0)
                {
                    AnimatorComponent.SetInteger("Direction", 1);
                    vertical = 1;
                }
                else
                {
                    AnimatorComponent.SetInteger("Direction", 3);
                    vertical = -1;
                }

                direction.y = vertical;
            }
            else if (horizontal != 0)
            {
                MoveEnabled = false;
                Invoke("EnableMovement", MoveDelay);
                if (horizontal > 0)
                {
                    AnimatorComponent.SetInteger("Direction", 2);
                    horizontal = 1;
                }
                else
                {
                    AnimatorComponent.SetInteger("Direction", 4);
                    horizontal = -1;
                }

                direction.x = horizontal;
            }
            else
            {
                AnimatorComponent.SetInteger("Direction", 0);
            }

            transform.Translate(direction);
            if (direction != OldDirection)
            {
                AnimatorComponent.SetTrigger("Change");
            }

            OldDirection = direction;
        }
    }

    private void EnableMovement()
    {
        MoveEnabled = true;
    }
}
