    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    //Different bomberman character game objects in editor
    [SerializeField] GameObject whiteGame;
    [SerializeField] GameObject blackGame;
    [SerializeField] GameObject redGame;
    [SerializeField] GameObject blueGame;

    Vector3 initialPosition = new Vector3(0, 0.2f, 1);

    // Start is called before the first frame update
    void Start()
    {
        if (CharacterSelectionFinal.bombermanCycle == 1)
        {
            GameObject player1 = Instantiate(whiteGame, initialPosition, Quaternion.identity) as GameObject;
            player1.transform.SetParent(gameObject.transform);
        }
        if (CharacterSelectionFinal.bombermanCycle == 2)
        {
            GameObject player1 = Instantiate(blackGame, initialPosition, Quaternion.identity) as GameObject;
            player1.transform.SetParent(gameObject.transform);
        }
        if (CharacterSelectionFinal.bombermanCycle == 3)
        {
            GameObject player1 = Instantiate(redGame, initialPosition, Quaternion.identity) as GameObject;
            player1.transform.SetParent(gameObject.transform);
        }
        if (CharacterSelectionFinal.bombermanCycle == 4)
        {
            GameObject player1 = Instantiate(blueGame, initialPosition, Quaternion.identity) as GameObject;
            player1.transform.SetParent(gameObject.transform);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
