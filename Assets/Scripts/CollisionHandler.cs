using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
   [Tooltip("In seconds")] [SerializeField] float lvlLoadDelay=2f;
    [Tooltip("Explosion to invoke")] [SerializeField] GameObject deathEffect = null;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathScenario();
    }

    private void StartDeathScenario()
    {
        SendMessage("OnPlayerDeath");
        deathEffect.SetActive(true);
        Invoke("ReloadCurrentScene",lvlLoadDelay);

    }

    void ReloadCurrentScene()//string reference
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
