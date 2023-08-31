using UnityEngine;
using System.Collections;

public class PlayerBomb2 : MonoBehaviour
{
    public GameObject playerBomb;
    private bool BombEnabled = true;

    void Update()
    {
        if (BombEnabled)
        {
            if (Input.GetAxisRaw("FireP2") == 1)
            {
                BombEnabled = false;
                Instantiate(playerBomb, new Vector3(Mathf.RoundToInt(transform.position.x),
                Mathf.RoundToInt(transform.position.y - 0.25f), 0),
                Quaternion.identity);
                Player2Movement.currentBombCount += 1;
            }
        }
        if (!BombEnabled)
        {
            if (Input.GetAxisRaw("FireP2") == 0 & PlayerMovement.currentBombCount < PlayerMovement.maxBombCount)
            {
                BombEnabled = true;
            }
        }
    }
}
