using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstepsSound, sprintSound, jumpSound;  

    void Update()
    {
        // Check if the player is moving (W, A, S, D keys)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            
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

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Stop all other sounds when jumping and play jump sound (This needs to be fixed because this isnt working)
            footstepsSound.enabled = false;
            sprintSound.enabled = false;
            jumpSound.enabled = true;
        }
        else
        {
            
            if (!Input.GetKey(KeyCode.Space))
            {
                jumpSound.enabled = false;
            }
        }
    }
}
