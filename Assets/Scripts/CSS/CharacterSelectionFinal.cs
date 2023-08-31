using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionFinal : MonoBehaviour
{
    //Cycle the bomberman characters
    public static int bombermanCycle = 1;

    //Different bomberman character game objects in editor
    [SerializeField] GameObject white;
    [SerializeField] GameObject black;
    [SerializeField] GameObject red;
    [SerializeField] GameObject blue;

    //Initial position of bomberman
    Vector3 initialPosition = new Vector3(0, -1, 0);

    //Control of player interaction in the scene
    private bool finalConfirm = false;
    public bool moveEnabled = true;
    public float sideMovement = 0;
    public int scrollDirection;
    private float flagDelay = 0.7f;

    //Reference to spawn newly created bombermen
    Vector3 leftEdge = new Vector3(-9f, -1, 0);
    Vector3 rightEdge = new Vector3(9f, -1, 0);

    Vector3 centerPosition = new Vector3(0, -1, 0);

    void Start()
    {
        GameObject playerWhite = Instantiate(white) as GameObject;
        white.transform.position = initialPosition;
    }

    void Update()
    {
        if (!finalConfirm)
        {
            //Cycle number back to 0
            if (bombermanCycle == 5)
            {
                bombermanCycle = 1;
            }
            //Cycle number back to 0
            if (bombermanCycle == 0)
            {
                bombermanCycle = 4;
            }
            if (moveEnabled)
            {
                sideMovement = Input.GetAxisRaw("Horizontal");
                if (sideMovement == 1)
                {
                    scrollDirection = 1;
                    CharacterSwap();
                    moveEnabled = false;
                    Invoke("FlagReset", flagDelay);
                }

                if (sideMovement == -1)
                {
                    scrollDirection = -1;
                    CharacterSwap();
                    moveEnabled = false;
                    Invoke("FlagReset", flagDelay);
                }
                if (Input.GetAxisRaw("Confirm") != 0)
                {
                    finalConfirm = true;
                    Invoke("SceneChange", 1);
                }
            }
        }
    }
    private void SceneChange()
    {
        SceneManager.LoadScene("Singleplayer Mode");
    }

    private void FlagReset()
    {
        sideMovement = 0;
        moveEnabled = true;
    }
    //Swap Characters
    public void CharacterSwap()
    {
        //Detect direcction of cycle swap
        if (scrollDirection >= 1)
        {
            //If swapping from white --> black
            if (bombermanCycle == 1)
            {
                GameObject playerselection = Instantiate(black, leftEdge, Quaternion.identity) as GameObject;
            }

            //If swapping from black to red
            else if (bombermanCycle == 2)
            {
                GameObject playerselection = Instantiate(red, leftEdge, Quaternion.identity) as GameObject;
            }

            //If swapping from red to blue
            else if (bombermanCycle == 3)
            {
                GameObject playerselection = Instantiate(blue, leftEdge, Quaternion.identity) as GameObject;
            }

            //If swapping from blue to white
            else if (bombermanCycle == 4)
            {
                GameObject playerselection = Instantiate(white, leftEdge, Quaternion.identity) as GameObject;
            }

            //Add 1 to bomberman cycle number
            bombermanCycle += 1;

            //Cycle number back to 1
            if (bombermanCycle >= 5)
            {
                bombermanCycle = 1;
            }
        }

        if (scrollDirection <= -1)
        {
            //If swapping from white --> blue
            if (bombermanCycle == 1)
            {
                GameObject playerselection = Instantiate(blue, rightEdge, Quaternion.identity) as GameObject;
            }

            //If swapping from blue to red
            else if (bombermanCycle == 4)
            {
                GameObject playerselection = Instantiate(red, rightEdge, Quaternion.identity) as GameObject;
            }

            //If swapping from red to black
            else if (bombermanCycle == 3)
            {
                GameObject playerselection = Instantiate(black, rightEdge, Quaternion.identity) as GameObject;
            }
                                                
            //If swapping from black to white
            else if (bombermanCycle == 2)
            {
                GameObject playerselection = Instantiate(white, rightEdge, Quaternion.identity) as GameObject;
            }

            //Subtract 1 from bomberman cycle number
            bombermanCycle -= 1;

            //Cycle number back to 4
            if (bombermanCycle <= 0)
            {
                bombermanCycle = 4;
            }
        }
    }
}
