using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] float timeForDestroy = 3f;
    void Start()
    {
        Destroy(gameObject, timeForDestroy);
    }

    
}
