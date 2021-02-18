using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector3 player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal") * player.x * Time.deltaTime;
        float zValue = Input.GetAxis("Vertical") * player.z * Time.deltaTime;
        transform.Translate(xValue, player.y, zValue);
    }
}
