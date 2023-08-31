using UnityEngine;
using System.Collections;

public class PlayerBomb1 : MonoBehaviour
{
    public GameObject playerBomb;
    private bool BombEnabled = true;

    void Update()
    {
        if (BombEnabled)
        {
            if (Input.GetAxisRaw("FireP1") == 1)
            {
                BombEnabled = false;
                Instantiate(playerBomb, new Vector3(Mathf.RoundToInt(transform.position.x),
                Mathf.RoundToInt(transform.position.y - 0.25f), 0),
                Quaternion.identity);
                Player1Movement.currentBombCount += 1;
            }
        }
        if (!BombEnabled)
        {
            if (Input.GetAxisRaw("FireP1") == 0 & PlayerMovement.currentBombCount < PlayerMovement.maxBombCount)
            {
                BombEnabled = true;
            }
        }
    }
}
