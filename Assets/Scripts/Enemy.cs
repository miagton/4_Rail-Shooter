using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionEffect = null;
    [SerializeField] Transform parent;
    [SerializeField] int hitsLeft = 2;
    [SerializeField] int scorePerHit = 20;

    ScoreBoard scoreBoard;

    private void Start()
    {
        AddNoneTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();


    }

    private void AddNoneTriggerBoxCollider()
    {
      Collider boxCollider=  gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProccesHit();
        if (hitsLeft <= 0)
        {
            KillEnemy();

        }
    }

    private void ProccesHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hitsLeft--;
    }

    private void KillEnemy()
    {
        if (explosionEffect != null)
        {
            GameObject fx = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            fx.transform.parent = parent;

        }
        Destroy(gameObject);
    }
}
