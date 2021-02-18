using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float yFactor = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, yFactor, 0f);
    }
}
