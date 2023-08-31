using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    //Reference to selection game object
    [SerializeField] private GameObject MenuSelector;

    //Reference to different menu option positions
    private Vector3 menuPosition1 = new Vector3 (-3, -1.55f, 0);
    private Vector3 menuPosition2 = new Vector3 (-3, -2.3f, 0);
    private Vector3 menuPosition3 = new Vector3 (-3, -2.9f, 0);

    //Reference to the option currently hovered
    private int menuSelected;
    //Forces user to press the key again to move selection instead of updating every frame
    private bool moveSelectEnabled = true;
    //Boolean to disable 
    private bool finalSelect = false;


    // Start is called before the first frame update
    void Start()
    {
        menuSelected = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finalSelect)
        {
            //Switch to move cursor
            switch (menuSelected)
            {
                case 1:
                    MenuSelector.transform.position = menuPosition1;
                    break;
                case 2:
                    MenuSelector.transform.position = menuPosition2;
                    break;
            }
            //Variable control to place cursor according to value of the variable
            if (moveSelectEnabled)
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    menuSelected += 1;
                    moveSelectEnabled = false;
                    if (menuSelected == 3)
                    {
                        menuSelected = 1;
                    }
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    menuSelected -= 1;
                    moveSelectEnabled = false;
                    if (menuSelected == 0)
                    {
                        menuSelected = 2;
                    }
                }
            }
            //Resets flag once key released
            if (!moveSelectEnabled)
            {
                if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    moveSelectEnabled = true;
                }
                if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    moveSelectEnabled = true;
                }
            }
            //Once confirmed, stop all controls using finalSelect
            if (Input.GetAxisRaw("Confirm") != 0)
            {
                Invoke("ChangeScene", 1);
                finalSelect = true;
            }
        }
    }
    //Scene change called once confirmed
    private void ChangeScene()
    {
        if (menuSelected == 1)
        {
            SceneManager.LoadScene("CSS");
        }
        if (menuSelected == 2)
        {
            SceneManager.LoadScene("Multiplayer Mode");
        }
    }
}
