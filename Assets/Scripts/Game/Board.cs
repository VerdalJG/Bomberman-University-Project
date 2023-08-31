using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour
{
    public GameObject BlockPrefab;
    public GameObject BlockDestructiblePrefab;
    private GameObject[,] BoardGame;
    private float randomChance = 7;

    private void Start()
    {
        //Create Array with 2 dimensions, X and Y, of size 31 by 17
        BoardGame = new GameObject[31, 17];

        for (int i = 2; i < 30; i += 2)
        {
            for (int j = 1; j < 15; j ++)
            {
                int randomPick = Mathf.RoundToInt(Random.Range(0, 10));
                if (randomPick <= randomChance)
                {   
                    GameObject blockDestructible = Instantiate(BlockDestructiblePrefab, new Vector2(i, j), Quaternion.identity);
                    blockDestructible.layer = 8;
                }
            }
        }
        for (int i = 1; i < 30; i += 2)
        {
            for (int j = 1; j < 15; j += 2)
            {
                int randomPick = Mathf.RoundToInt(Random.Range(0, 10));
                if (randomPick <= randomChance)
                {
                    GameObject blockDestructible = Instantiate(BlockDestructiblePrefab, new Vector2(i, j), Quaternion.identity);
                    blockDestructible.layer = 8;
                }
            }
        }


        for (int i = 1; i < 31; i += 2)
        {
            for (int j = 1; j < 17; j += 2)
            {
                GameObject block = Instantiate(BlockPrefab, new Vector2(i, j), Quaternion.identity);
                block.transform.parent = transform;
                BoardGame[i, j] = block;
            }
        }
        //Create array named blocks of one dimension, finding all objects with tag block
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("BlockDestructible");
        for (int i = 0; i < blocks.Length; ++i)
        {
            Vector2 pos = WorldToBoard(blocks[i].transform.position);
            BoardGame[(int)pos.x, (int)pos.y] = blocks[i];
        }
    }

    public Vector2 WorldToBoard(Vector2 position)
    {
        Vector2 result = new Vector2
        {
            x = Mathf.Floor(position.x),
            y = Mathf.Floor(position.y)
        };

        return result;
    }

    public bool ValidPosition(int x, int y)
    {
        if ((x < 0) || (29 <= x) || (y < 0) || (15 <= y) || (BoardGame[x, y] != null))
        {
            return false;
        }

        return true;
    }

    public GameObject GetBlockAt(int x, int y)
    {
        if ((x < 0) || (29 <= x) || (y < 0) || (15 <= y))
        {
            return null;
        }

        return BoardGame[x, y];
    }
}
