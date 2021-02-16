using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    BoxCollider myBoxCollider;

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hits = 10;
    // Start is called before the first frame update
    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        myBoxCollider = gameObject.AddComponent<BoxCollider>();
        myBoxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        hits--;
        if(hits <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;

        scoreBoard.HitScore(scorePerHit);

        Destroy(gameObject);
    }
}
