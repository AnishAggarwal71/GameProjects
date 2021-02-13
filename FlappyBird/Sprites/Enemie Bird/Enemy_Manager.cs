using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{
    public Rigidbody2D enemy;
    public int speed = -10;

    public void OnAwake()
    {
        enemy = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.velocity = transform.right * speed * Time.deltaTime;
    }
}
