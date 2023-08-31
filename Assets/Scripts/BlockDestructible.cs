    using UnityEngine;

public class BlockDestructible : MonoBehaviour
{
    private Animator AnimatorComponent;
    public GameObject FireUp;
    public GameObject FireDown;
    public GameObject BombUp;
    public GameObject BombDown;
    private int FireUpChance = 1;
    private int FireDownChance = 2;
    private int BombUpChance = 3;
    private int BombDownChance = 4;
    private int RandomChance;
    private GameObject PowerUp;



    private void Start()
    {
        AnimatorComponent = GetComponent<Animator>();
    }

    public void BeginDestroy()
    {
        AnimatorComponent.SetTrigger("Destroy");
    }

    public void EndDestroy()
    {
        int RandomChance = Mathf.RoundToInt(Random.Range(0, 16));
        if (RandomChance == FireUpChance)
        {
            PowerUp = Instantiate(FireUp, transform.position, Quaternion.identity);
        }
        else if (RandomChance == FireDownChance)
        {
            PowerUp = Instantiate(FireDown, transform.position, Quaternion.identity);
        }
        else if (RandomChance == BombUpChance)
        {
            PowerUp = Instantiate(BombUp, transform.position, Quaternion.identity);
        }
        else if (RandomChance == BombDownChance)
        {
            PowerUp = Instantiate(BombDown, transform.position, Quaternion.identity);
        }
        else
        {

        }
        Destroy(gameObject);
    }
}
