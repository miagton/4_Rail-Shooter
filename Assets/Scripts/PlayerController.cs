using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; 

public class PlayerController : MonoBehaviour
{   [Header("General")]
    [Tooltip("in meters per second")]  [SerializeField] float controlSpeed=20f;
    [SerializeField] float maxXOffset = 11f;
    [SerializeField] float maxYOffset = 9f;
    [SerializeField] GameObject[] lazers = null;
    
    [Header("Screen position based")]
    [SerializeField]float positionPitchFactor = -4f;
    [SerializeField] float positionYawFactor = 4f;
    
    [Header("Control throw based")]
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -15f;
   
    float xThrow, yThrow;
    bool isControlEnabled = true;

    ScoreBoard scoreBoard;
    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
          Move();
          Rotate();
          Shoot();
        }
        
    }

   

    void OnPlayerDeath()//called by string reference
    {
       
        isControlEnabled = false;
    }
    

    private void Rotate()
    {
        float pitch=transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;

        float yaw = transform.localPosition.x * positionYawFactor;
       
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void Move()
    {
                     
        transform.localPosition = new Vector3(CountHorizontalMove(), CountVerticalMove(), transform.localPosition.z);

    }
    float CountVerticalMove()
    {
         yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float newYPos = Mathf.Clamp(rawNewYPos, -maxYOffset, maxYOffset);
        return newYPos;
       
    }
    float CountHorizontalMove()
    {
         xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float newXPos = Mathf.Clamp(rawNewXPos, -maxXOffset, maxXOffset);
        return newXPos;
    }
    void Shoot()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateLazers(true);
        }
        else
        {
            ActivateLazers(false);
        }
    }

    private void ActivateLazers(bool isActive)
    {
        foreach(GameObject lazer in lazers)
        {
            var lazerEmmision=  lazer.GetComponent<ParticleSystem>().emission;
            lazerEmmision.enabled = isActive;
        }
    }
    
    
}
