using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    private Animator AnimatorComponent;
    // Start is called before the first frame update
    void Start()
    {
        AnimatorComponent = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorComponent.SetTrigger("Destroy");
    }
    public void EndDestroy()
    {
        Destroy(gameObject);
    }
}
