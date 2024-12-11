using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCollision : MonoBehaviour
{
    // Respawn position for dog
    private Vector3 startingPosition = new Vector3(-587, 1, 139);
    // Camera position
    public Transform cameraTransform;

    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        // Only respawn the dog when he hits the obstacle
        if (other.CompareTag("Obstacle"))
        {
            // Set him back to the starting position if he hits the obstacle
            transform.position = startingPosition;

            // Call GameOver to show "Game Restart" text
            gameManager.GameOver(); 

            // Adjust the camera position to look at the dog again
            if (cameraTransform != null)
            {
                cameraTransform.LookAt(transform);
            }
        }
    }
}

