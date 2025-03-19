using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstepsSound, sprintSound, jumpSound;  // Added jumpSound for the jump audio

    void Update()
    {
        // Check if the player is moving (W, A, S, D keys)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            // Check if the player is sprinting (Left Shift key)
            if (Input.GetKey(KeyCode.LeftShift))
            {
                footstepsSound.enabled = false;
                sprintSound.enabled = true;
            }
            else
            {
                footstepsSound.enabled = true;
                sprintSound.enabled = false;
            }
        }
        else
        {
            footstepsSound.enabled = false;
            sprintSound.enabled = false;
        }

        // Check if the player presses the jump button (space bar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Stop all other sounds when jumping and play jump sound
            footstepsSound.enabled = false;
            sprintSound.enabled = false;
            jumpSound.enabled = true;
        }
        else
        {
            // Ensure jump sound stops when not jumping
            if (!Input.GetKey(KeyCode.Space))
            {
                jumpSound.enabled = false;
            }
        }
    }
}
