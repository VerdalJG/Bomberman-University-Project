using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    public Animation explode;
    // Start is called before the first frame update
    void Start()
    {
        explode = GetComponent<Animation>();
        Destroy(gameObject, explode.clip.length);
    }
}
