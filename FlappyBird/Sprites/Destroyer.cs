using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public int i;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(i==0)
        {
            PlayerController.instance.health = 0f;
        }
        else
        Destroy(collision.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
