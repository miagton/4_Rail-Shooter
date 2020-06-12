using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; 

public class Player : MonoBehaviour
{
    [Tooltip("in meters per second")]  [SerializeField] float xSpeed=20f;
    [Tooltip("in meters per second")] [SerializeField] float ySpeed = 20f;
    [SerializeField] float maxXOffset = 11f;
    [SerializeField] float maxYOffset = 9f;
    [SerializeField]float positionPitchFactor = -4f;
    [SerializeField] float controlPitchFactor = -15f;

    float xThrow, yThrow;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        
    }

    private void Rotate()
    {
        float pitch=transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw=0f;
        float roll = 0f; ;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void Move()
    {
                     
        transform.localPosition = new Vector3(CountHorizontalMove(), CountVerticalMove(), transform.localPosition.z);

    }
    float CountVerticalMove()
    {
         yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float newYPos = Mathf.Clamp(rawNewYPos, -maxYOffset, maxYOffset);
        return newYPos;
       
    }
    float CountHorizontalMove()
    {
         xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float newXPos = Mathf.Clamp(rawNewXPos, -maxXOffset, maxXOffset);
        return newXPos;
    }
}
