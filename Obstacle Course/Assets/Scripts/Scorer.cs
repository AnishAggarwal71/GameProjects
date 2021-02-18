using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int bumps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Safe")
        {
            ++bumps;

            Debug.Log("You have bumped into something this many time: " + bumps);
        }
    }
}
