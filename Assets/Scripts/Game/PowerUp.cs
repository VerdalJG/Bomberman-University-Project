using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.StartsWith("Player"))
        {
            if (gameObject.name.StartsWith("FireUp"))
            {
                PlayerMovement.fireNumber += 1;
            }
            if (gameObject.name.StartsWith("FireDown"))
            {
                PlayerMovement.fireNumber -= 1;
            }
            if (gameObject.name.StartsWith("BombUp"))
            {
                PlayerMovement.maxBombCount += 1;
            }
            if (gameObject.name.StartsWith("BombDown"))
            {
                PlayerMovement.maxBombCount -= 1;
            }
            Destroy(gameObject);
        }
    }
}
