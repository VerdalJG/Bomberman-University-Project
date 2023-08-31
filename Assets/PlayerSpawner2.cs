using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner2 : MonoBehaviour
{
    [SerializeField] GameObject blackGame;

    Vector3 initialPosition = new Vector3(28, 0.2f, 1);

    // Start is called before the first frame update
    void Start()
    {
        GameObject player2 = Instantiate(blackGame, initialPosition, Quaternion.identity) as GameObject;
        player2.transform.SetParent(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
