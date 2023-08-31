    using UnityEngine;

public class BombermanDrop : MonoBehaviour
{
    public GameObject BombPrefab;
    public float BombDelay;
    private bool BombEnabled = true;

    void Update()
    {
        if (BombEnabled && (Input.GetButtonDown("Fire1")))
        {
            BombEnabled = false;
            Instantiate(BombPrefab, transform.position, Quaternion.identity);
            Invoke("EnableBomb", BombDelay);
        }
    }

    private void EnableBomb()
    {
        BombEnabled = true;
    }
}
