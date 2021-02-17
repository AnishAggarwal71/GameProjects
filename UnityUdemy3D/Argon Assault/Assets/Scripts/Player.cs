using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    float xThrow, yThrow;
    bool areControlsEnabled = true;

    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 15f;
    [Tooltip("In m")] [SerializeField] float xRange = 4f;

    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 9f;
    [Tooltip("In m")] [SerializeField] float yMinRange = -4f;
    [Tooltip("In m")] [SerializeField] float yMaxRange = 4f;

    [Header("Screen-Position based")]
    [Tooltip("Along X axis")] [SerializeField] float positionYawFactor = -5f;
    [Tooltip("Along Y axis")][SerializeField] float positionPitchFactor = 1f;

    [Header("Control-Throw Based")]
    [Tooltip("Along X axis")] [SerializeField] float controlRollFactor = -30f;
    [Tooltip("Along Y axis")][SerializeField] float controlPitchFactor = -20f;

    [SerializeField] GameObject[] guns;

    // Update is called once per frame
    void Update()
    {
        if (areControlsEnabled) {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
        
    }

    void OnPlayerDeath()  //Called by String Reference
    {
        areControlsEnabled = false;
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float xPos = Mathf.Clamp(rawXPos, -xRange, xRange);


        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawYPos = transform.localPosition.y + yOffset;
        float yPos = Mathf.Clamp(rawYPos, yMinRange, yMaxRange);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            ParticleSystem.EmissionModule emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
