﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionEffect = null;
    [SerializeField] Transform parent;

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
        if (explosionEffect != null)
        {
       GameObject fx= Instantiate(explosionEffect, transform.position,Quaternion.identity);
            fx.transform.parent = parent;

        }
        scoreBoard.ScoreHit();
        Destroy(gameObject);
    }
}
