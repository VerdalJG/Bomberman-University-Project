using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTimer : MonoBehaviour
{
    public bool explosionTrigger = false;
    private Animator MenuSelector;

    private void Start()
    {
        explosionTrigger = false;
        MenuSelector = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!explosionTrigger)
        {

            if (Input.GetAxisRaw("Confirm") != 0)
            {
                Invoke("Explode", 0);
                explosionTrigger = true;               
            }
            
        }
    }

    void Explode()
    {
        MenuSelector.SetTrigger("Selected");
    }
}
